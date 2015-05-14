namespace Realm.Library.Database.Framework
{
    /// <summary>
    /// The state of the transaction
    /// </summary>
    public enum TransactionState
    {
        /// <summary>
        /// The transaction is in a Building state
        /// </summary>
        Building,

        /// <summary>
        /// The transaction is being executed
        /// </summary>
        Executing,

        /// <summary>
        /// The transaction has executed and is being processed
        /// </summary>
        Processing,

        /// <summary>
        /// The transaction is being cancelled
        /// </summary>
        Cancelling
    }
}