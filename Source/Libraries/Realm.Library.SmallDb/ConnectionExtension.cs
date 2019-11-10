using System.Data;

namespace Realm.Library.SmallDb
{
    /// <summary>
    /// 
    /// </summary>
    public static class ConnectionExtension
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="connection"></param>
        public static void CleanupConnection(this IDbConnection connection)
        {
            if (connection.State != ConnectionState.Closed)
                connection.Close();
            connection.Dispose();
        }
    }
}
