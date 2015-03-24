using System;
using System.Collections.Generic;
using System.Linq;
using Realm.Library.Common;
using Realm.Library.Common.Data;
using Realm.Library.Database.Properties;

namespace Realm.Library.Database.Framework
{
    /// <summary>
    /// Database client handles the building and receiving of database commands and transactions
    /// </summary>
    public class DatabaseClient : IEntityModule, IDisposable
    {
        private int _transactionId;

        private readonly Dictionary<int, PendingTransaction> _pendingTransactions =
            new Dictionary<int, PendingTransaction>();

        private PendingTransaction _currentTransaction;
        private readonly IDatabaseLoadBalancer _loadBalancer;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="owner"></param>
        /// <param name="loadBalancer"></param>
        public DatabaseClient(IEntity owner, IDatabaseLoadBalancer loadBalancer)
        {
            Owner = owner;
            _loadBalancer = loadBalancer;
        }

        /// <summary>
        /// Owner of the module
        /// </summary>
        public IEntity Owner { get; private set; }

        /// <summary>
        /// Starts a new transaction set
        /// </summary>
        /// <returns></returns>
        public virtual int BeginTransaction()
        {
            _transactionId++;
            _currentTransaction = new PendingTransaction(this, _transactionId);
            return _transactionId;
        }

        /// <summary>
        /// Cancels an existing transaction
        /// </summary>
        /// <param name="transactionId"></param>
        /// <returns></returns>
        public virtual bool CancelTransaction(int transactionId)
        {
            Validation.Validate<ArgumentOutOfRangeException>(transactionId > 0 && transactionId <= Int32.MaxValue);

            var returnVal = false;

            if (_pendingTransactions.ContainsKey(transactionId))
            {
                var transaction = _pendingTransactions[transactionId];
                if (transaction.State != TransactionState.Executing)
                {
                    transaction.State = TransactionState.Cancelling;
                    returnVal = _pendingTransactions.Remove(transactionId);
                }
            }

            return returnVal;
        }

        /// <summary>
        /// Executes the transaction
        /// </summary>
        /// <param name="callback"></param>
        /// <param name="data"></param>
        public virtual void PerformTransaction(EventCallback<RealmEventArgs> callback, DictionaryAtom data)
        {
            Validation.IsNotNull(callback, "callback");
            Validation.Validate(_currentTransaction.State == TransactionState.Building);

            _currentTransaction.Callback = callback;
            _currentTransaction.TransactionCallback = OnTransactionComplete;
            _currentTransaction.Data = data;
            _pendingTransactions.Add(_transactionId, _currentTransaction);

            _loadBalancer.ExecuteTransaction(_currentTransaction);

            _currentTransaction = null;
        }

        /// <summary>
        /// Add a new database command to the current transaction set
        /// </summary>
        /// <param name="schema"> </param>
        /// <param name="commandName"></param>
        /// <param name="args"></param>
        /// <param name="callback"></param>
        /// <param name="data"></param>
        public virtual void AddCommand(string schema, string commandName, DictionaryAtom args = null,
                               EventCallback<RealmEventArgs> callback = null, DictionaryAtom data = null)
        {
            Validation.IsNotNullOrEmpty(schema, "schema");
            Validation.IsNotNullOrEmpty(commandName, "commandName");
            Validation.Validate(_currentTransaction.State == TransactionState.Building);

            var pendingCommand = new PendingCommand(this)
                                     {
                                         Callback = callback,
                                         Data = data
                                     };

            _currentTransaction.PendingCommands.Add(pendingCommand);

            var dbCommandDictionary = new DictionaryAtom();
            dbCommandDictionary.Set("schema", schema);
            dbCommandDictionary.Set("commandName", commandName);
            dbCommandDictionary.Set("parameters", args);

            _currentTransaction.DbCommands.Add(dbCommandDictionary);
        }

        /// <summary>
        /// Callback function which handles the response of a transaction from a DatabaseServer
        /// </summary>
        /// <param name="args"></param>
        private void OnTransactionComplete(DatabaseResponseEventArgs args)
        {
            Validation.IsNotNull(args, "args");

            var transactionId = args.TransactionId;
            Validation.Validate(transactionId <= 0, Resources.ERR_INVALID_TRANS_ID);
            Validation.Validate(!_pendingTransactions.ContainsKey(transactionId),
                                Resources.ERR_PENDING_TRANS_NOT_FOUND, transactionId);

            var transaction = _pendingTransactions[transactionId];
            Validation.Validate(transaction.State == TransactionState.Processing);

            var commandResults = args.CommandResults;
            var itResult = commandResults.GetEnumerator();
            var itCommand = transaction.PendingCommands.GetEnumerator();

            while (itResult.MoveNext() && itCommand.MoveNext())
            {
                var result = itResult.Current;
                var command = itCommand.Current;

                IssueCallback(command.Callback, args.Success, result, command.Data);
            }

            IssueCallback(transaction.Callback, args.Success, commandResults, transaction.Data);

            _pendingTransactions.Remove(transactionId);
        }

        /// <summary>
        /// Submits the given callback with the passed data fields
        /// </summary>
        /// <param name="callback"></param>
        /// <param name="success"></param>
        /// <param name="result"></param>
        /// <param name="data"></param>
        private static void IssueCallback(EventCallback<RealmEventArgs> callback, bool success, Atom result, DictionaryAtom data)
        {
            if (callback.IsNull()) return;

            callback.Invoke(new RealmEventArgs(new EventTable
                                                   {
                                                       {"userData", data},
                                                       {"commandResult", result},
                                                       {"success", success}
                                                   }));
        }

        #region IDisposable

        /// <summary>
        /// Overrides the base Dispose to make this object disposable
        /// </summary>
        public void Dispose()
        {
            Dispose(true);

            // Use SupressFinalize in case a subclass
            // of this type implements a finalizer.
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Dispose of any internal resources
        /// </summary>
        /// <param name="disposing"></param>
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_currentTransaction.IsNotNull())
                    _currentTransaction.PendingCommands.Clear();
                if (_pendingTransactions.IsNotNull())
                {
                    _pendingTransactions.Values.ToList().ForEach(x => x.PendingCommands.Clear());
                    _pendingTransactions.Clear();
                }
            }
        }

        #endregion IDisposable
    }
}