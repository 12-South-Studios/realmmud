using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Realm.Library.Common;
using Realm.Library.Common.Data;
using Realm.Library.Common.Exceptions;
using Realm.Library.Common.Extensions;
using Realm.Library.Common.Logging;
using Realm.Library.Common.Objects;
using Realm.Library.Database.Properties;

namespace Realm.Library.Database.Framework
{
    /// <summary>
    /// Database Server class handles the execution of database procedures
    /// </summary>
    public sealed class DatabaseServer : Entity
    {
        private readonly Dictionary<Task, CancellationTokenSource> _tasks;
        private readonly IDbConnection _connection;
        private readonly IList<IProcedureRepository> _procedureRepositories;
        private readonly ILogWrapper _log;

        /// <summary>
        ///
        /// </summary>
        /// <param name="id"></param>
        /// <param name="connectionString"></param>
        /// <param name="log"></param>
        /// <param name="procedureLoaders"></param>
        public DatabaseServer(long id, string connectionString, ILogWrapper log, IEnumerable<IProcedureLoader> procedureLoaders)
            : base(id, "DatabaseServer" + id)
        {
            Validation.Validate<ArgumentOutOfRangeException>(id >= 1);
            Validation.IsNotNullOrEmpty(connectionString, "connectionString");
            Validation.IsNotNull(log, "log");
            Validation.IsNotNull(procedureLoaders, "procedureLoaders");
            Validation.Validate(procedureLoaders.Any());

            _log = log;
            _connection = new SqlConnection(connectionString);
            _connection.Open();
            _connection.Close();

            _tasks = new Dictionary<Task, CancellationTokenSource>();

            _procedureRepositories = new List<IProcedureRepository>();
            procedureLoaders.ToList().ForEach(x => _procedureRepositories.Add(x.ProcedureRepository));
            procedureLoaders.ToList().ForEach(x => _log.DebugFormat("ProcedureLoader {0} has {1} stored procedures.", x.GetType(), x.ProcedureRepository.Count));
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="disposing"></param>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_connection != null && _connection.State != ConnectionState.Closed)
                    _connection.Dispose();

                using (var it = _tasks.GetEnumerator())
                {
                    while (it.MoveNext())
                    {
                        _tasks.Remove(it.Current.Key);
                        it.Current.Key.Cancel(it.Current.Value);
                    }
                }
            }
            base.Dispose(disposing);
        }

        /// <summary>
        /// Spins up a new task to execute the transaction
        /// </summary>
        /// <param name="transaction"></param>
        [SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes",
                 Justification = "Catching all Exceptions because of the Invoke that is called downstream")]
        public void ExecuteTransaction(PendingTransaction transaction)
        {
            Validation.IsNotNull(transaction, "transaction");
            Validation.IsNotNull(transaction.DbCommands, "transaction.DbCommands");

            _log.InfoFormat(Resources.MSG_TRANS_SUBMIT, transaction.TransactionId);

            Task<TransactionResponse> task = null;
            CancellationTokenSource tokenSource = null;

            try
            {
                tokenSource = new CancellationTokenSource();
                task = Task.Factory.StartNew(() => ExecuteNextTransaction(tokenSource.Token, transaction), tokenSource.Token);

                _tasks.Add(task, tokenSource);
                task.Wait(tokenSource.Token);

                IssueCallback(transaction, task.Result);

                _log.InfoFormat(Resources.MSG_TRANS_COMPLETE, transaction.TransactionId, task.Status);
            }
            catch (AggregateException ex)
            {
                _log.InfoFormat(Resources.MSG_TRANS_CANCELLED, transaction.TransactionId);
                ex.InnerException.Handle(ExceptionHandlingOptions.RecordAndThrow, _log);
            }
            catch (Exception ex)
            {
                ex.Handle(ExceptionHandlingOptions.RecordAndThrow, _log);
            }
            finally
            {
                if (task != null)
                {
                    if (_tasks.ContainsKey(task))
                        _tasks.Remove(task);
                    task.Cancel(tokenSource);
                }
            }
        }

        /// <summary>
        /// Executes the provided transaction
        /// </summary>
        private TransactionResponse ExecuteNextTransaction(CancellationToken token, PendingTransaction transaction)
        {
            Validation.IsNotNull(token, "token");
            Validation.IsNotNull(transaction, "transaction");

            token.ThrowIfCancellationRequested();

            var success = true;
            var commandResults = new ListAtom();

            transaction.State = TransactionState.Executing;
            var sqlTransaction = _connection.BeginTransaction();

            try
            {
                using (var it = transaction.DbCommands.GetEnumerator())
                {
                    while (it.MoveNext())
                    {
                        var dbCommand = it.Current.CastAs<DictionaryAtom>();
                        if (!success) continue;
                        var resultSet = ExecuteProcedure(dbCommand);
                        if (resultSet == null || (resultSet.ContainsKey("success") && !resultSet.GetBool("success")))
                            success = false;

                        commandResults.Add(resultSet ?? new DictionaryAtom());
                    }
                }
            }
            catch (SqlException ex)
            {
                ex.Handle(ExceptionHandlingOptions.RecordOnly, _log);
                success = false;
            }
            finally
            {
                TryRollbackOrCommit(sqlTransaction, success);
            }

            SetResultSetSuccess(commandResults, success);

            return new TransactionResponse
                    {
                        Success = success,
                        CommandResults = commandResults
                    };
        }

        /// <summary>
        /// Sets the resultsets in the results to the success state
        /// </summary>
        /// <param name="commandResults"></param>
        /// <param name="success"></param>
        private static void SetResultSetSuccess(IEnumerable<Atom> commandResults, bool success)
        {
            if (success) return;

            commandResults.Select(resultAtom => resultAtom.CastAs<DictionaryAtom>())
                          .ToList()
                          .ForEach(resultSet => resultSet.Set("success", false));
        }

        /// <summary>
        /// Executes the procedure using the given command variables
        /// </summary>
        /// <param name="dbCommand"></param>
        /// <returns></returns>
        [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope",
                 Justification = "DataTable is disposed, but cannot use the Using scope because it is passed ByReference")]
        private DictionaryAtom ExecuteProcedure(DictionaryAtom dbCommand)
        {
            Validation.IsNotNull(dbCommand, "dbCommand");

            var dbSchema = dbCommand.GetString("schema");
            var dbCommandName = dbCommand.GetString("commandName");
            var proc = GetProcedure(dbSchema, dbCommandName);
            if (proc == null)
                throw new ObjectNotFoundException(string.Format(Resources.ERR_DB_PROC_NOT_FOUND, dbSchema, dbCommandName));

            var dbParameterSet = dbCommand.GetAtom<DictionaryAtom>("parameters");

            var executor = new ProcedureExecutor<SqlCommand>(_connection, _log, proc);
            var result = executor.ExecuteQuery(dbParameterSet?.ToDictionary());
            var dataTable = result.Item2.CastAs<DataTable>();

            var resultSet = new DictionaryAtom();
            resultSet.Set("Results", dataTable.ToListAtom());
            resultSet.Set("Schema", dbSchema);
            resultSet.Set("CommandName", dbCommandName);

            dataTable.Dispose();
            return resultSet;
        }

        /// <summary>
        /// Gets the procedure with the given name and schema from the repositories
        /// </summary>
        /// <param name="schema"> </param>
        /// <param name="commandName"></param>
        /// <returns></returns>
        private IProcedure GetProcedure(string schema, string commandName)
        {
            return (from repository in _procedureRepositories
                    let key = repository.Keys.SingleOrDefault(x => x.IsEqual(schema, commandName))
                    where key != null
                    select repository.Get(key)).FirstOrDefault();
        }

        /// <summary>
        /// Attempt to commit the transaction or roll it back if an exception occurred
        /// </summary>
        /// <param name="transaction"></param>
        /// <param name="success"></param>
        private void TryRollbackOrCommit(IDbTransaction transaction, bool success)
        {
            Validation.IsNotNull(transaction, "transaction");

            try
            {
                transaction.RollbackOrCommit(success ? TransactionAction.Commit : TransactionAction.Rollback);
            }
            catch (SqlException ex)
            {
                ex.Handle(ExceptionHandlingOptions.RecordAndThrow, _log);
            }
        }

        /// <summary>
        /// Submits the given callback with the passed data fields
        /// </summary>
        /// <param name="transaction"></param>
        /// <param name="response"></param>
        private static void IssueCallback(PendingTransaction transaction, TransactionResponse response)
        {
            Validation.IsNotNull(transaction, "transaction");
            Validation.IsNotNull(response, "response");

            if (transaction.Callback == null) return;

            transaction.State = TransactionState.Processing;
            transaction.TransactionCallback.Invoke(new DatabaseResponseEventArgs
                                                       {
                                                           Success = response.Success,
                                                           TransactionId = transaction.TransactionId,
                                                           CommandResults = response.CommandResults
                                                       });
        }

        /// <summary>
        /// Internal class defined to handle a response from the transaction call
        /// </summary>
        private class TransactionResponse
        {
            /// <summary>
            ///
            /// </summary>
            public bool Success { get; set; }

            /// <summary>
            ///
            /// </summary>
            public ListAtom CommandResults { get; set; }
        }
    }
}