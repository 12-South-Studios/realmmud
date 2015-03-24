namespace Realm.Library.Database.Framework
{
    /// <summary>
    ///
    /// </summary>
    public interface IDatabaseLoadBalancer
    {
        /// <summary>
        ///
        /// </summary>
        /// <param name="transaction"></param>
        void ExecuteTransaction(PendingTransaction transaction);
    }
}