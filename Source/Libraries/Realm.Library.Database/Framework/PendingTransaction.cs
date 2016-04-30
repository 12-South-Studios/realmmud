using System.Collections.Generic;
using System.Linq;
using Realm.Library.Common;
using Realm.Library.Common.Data;
using Realm.Library.Common.Events;

namespace Realm.Library.Database.Framework
{
    /// <summary>
    ///
    /// </summary>
    public class PendingTransaction
    {
        private readonly IList<PendingCommand> _pendingCommands;

        /// <summary>
        ///
        /// </summary>
        /// <param name="owner"></param>
        /// <param name="transactionId"></param>
        public PendingTransaction(DatabaseClient owner, int transactionId)
        {
            Owner = owner;
            TransactionId = transactionId;
            State = TransactionState.Building;

            _pendingCommands = new List<PendingCommand>();
        }

        /// <summary>
        ///
        /// </summary>
        private DatabaseClient Owner { get; set; }

        /// <summary>
        ///
        /// </summary>
        public int TransactionId { get; private set; }

        /// <summary>
        ///
        /// </summary>
        public TransactionState State { get; set; }

        /// <summary>
        ///
        /// </summary>
        public DictionaryAtom Data { get; set; }

        /// <summary>
        ///
        /// </summary>
        public EventCallback<DatabaseResponseEventArgs> TransactionCallback { get; set; }

        /// <summary>
        ///
        /// </summary>
        public EventCallback<RealmEventArgs> Callback { get; set; }

        /// <summary>
        ///
        /// </summary>
        public IList<PendingCommand> PendingCommands => _pendingCommands.ToList();

        /// <summary>
        ///
        /// </summary>
        /// <param name="command"></param>
        public void AddPendingCommand(PendingCommand command)
        {
            Validation.IsNotNull(command, "command");

            if (!_pendingCommands.Contains(command))
                _pendingCommands.Add(command);
        }

        /// <summary>
        ///
        /// </summary>
        public ListAtom DbCommands { get; set; }
    }
}