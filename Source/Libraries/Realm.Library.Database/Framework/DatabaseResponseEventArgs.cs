using System;
using Realm.Library.Common.Data;

namespace Realm.Library.Database.Framework
{
    /// <summary>
    /// Argument class that encapsulates a previously submitted database transaction
    /// </summary>
    public class DatabaseResponseEventArgs : EventArgs
    {
        /// <summary>
        /// Id of the transaction that was submitted
        /// </summary>
        public int TransactionId { get; set; }

        /// <summary>
        /// List of results from the command(s)
        /// </summary>
        public ListAtom CommandResults { get; set; }

        /// <summary>
        /// Flag indicating the success or failure of one or more commands within the transaction
        /// </summary>
        public bool Success { get; set; }
    }
}