using System.Data;

namespace Realm.Library.SmallDb
{
    public static class ConnectionExtension
    {
        public static void CleanupConnection(this IDbConnection connection)
        {
            if (connection.State != ConnectionState.Closed)
                connection.Close();
            connection.Dispose();
        }
    }
}
