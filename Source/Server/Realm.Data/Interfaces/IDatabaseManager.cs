using Realm.Library.Database.Framework;

namespace Realm.Data.Interfaces
{
    /// <summary>
    ///
    /// </summary>
    public interface IDatabaseManager
    {
        /// <summary>
        ///
        /// </summary>
        /// <param name="transaction"></param>
        void ExecuteTransaction(PendingTransaction transaction);
    }
}