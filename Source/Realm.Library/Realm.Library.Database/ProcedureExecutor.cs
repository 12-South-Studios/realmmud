using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Diagnostics.CodeAnalysis;
using Realm.Library.Common;
using Realm.Library.Common.Logging;

namespace Realm.Library.Database
{
    /// <summary>
    ///
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ProcedureExecutor<T> where T : IDbCommand, new()
    {
        private readonly IProcedure _procedure;
        private readonly IDbConnection _connection;
        private readonly LogWrapper _log;

        /// <summary>
        ///
        /// </summary>
        /// <param name="connection"></param>
        /// <param name="log"></param>
        /// <param name="procedure"></param>
        public ProcedureExecutor(IDbConnection connection, LogWrapper log, IProcedure procedure)
        {
            Validation.IsNotNull(connection, "connection");
            Validation.IsNotNull(log, "log");
            Validation.IsNotNull(procedure, "procedure");

            _procedure = procedure;
            _log = log;
            _connection = connection;
        }

        /// <summary>
        /// Executes the procedure with a given command and dictionary of arguments
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        [SuppressMessage("Microsoft.Security", "CA2100:ReviewSqlQueriesForSecurityVulnerabilities")]
        public int ExecuteNonQuery(IDictionary<string, object> args)
        {
            var returnVal = -1;
            try
            {
                if (!_connection.TryOpen()) return returnVal;

                using (var command = new T() as IDbCommand)
                {
                    command.Connection = _connection;
                    command.CommandType = _procedure.CommandType;
                    command.CommandText = _procedure.CommandText;

                    if (args.IsNotNull()) command.PopulateCommandArgs(_procedure.Parameters, args);

                    returnVal = command.ExecuteNonQuery();
                }
            }
            catch (DbException ex)
            {
                ex.Handle(ExceptionHandlingOptions.RecordOnly, _log, ToString(), ex);
            }
            catch (InvalidOperationException ex)
            {
                ex.Handle(ExceptionHandlingOptions.RecordAndThrow, _log, ToString(), ex);
            }
            return returnVal;
        }

        /// <summary>
        /// Executes the procedure with the given command and dictionary of arguments
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        [SuppressMessage("Microsoft.Security", "CA2100:ReviewSqlQueriesForSecurityVulnerabilities")]
        public Tuple<int, DataTable> ExecuteQuery(IDictionary<string, object> args)
        {
            var returnVal = -1;
            DataTable dataTable = null;

            try
            {
                if (!_connection.TryOpen()) return new Tuple<int, DataTable>(returnVal, null);

                using (var command = new T() as IDbCommand)
                {
                    command.Connection = _connection;
                    command.CommandType = _procedure.CommandType;
                    command.CommandText = _procedure.CommandText;

                    if (args.IsNotNull()) command.PopulateCommandArgs(_procedure.Parameters, args);

                    dataTable = new DataTable();
                    using (var dataReader = command.ExecuteReader())
                    {
                        if (dataReader.IsNotNull()) 
                            dataTable.Load(dataReader);
                    }

                    if (dataTable.IsNotNull() && dataTable.Rows.IsNotNull())
                        returnVal = dataTable.Rows.Count;
                }
            }
            catch (DbException ex)
            {
                ex.Handle(ExceptionHandlingOptions.RecordOnly, _log, ToString(), ex);
            }
            catch (InvalidOperationException ex)
            {
                ex.Handle(ExceptionHandlingOptions.RecordAndThrow, _log, ToString(), ex);
            }
            return new Tuple<int, DataTable>(returnVal, dataTable);
        }
    }
}