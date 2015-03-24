namespace Realm.Build.Tool
{
    public static class DatabaseUtils
    {
        public static string GetSqlConnectionString(string server, string database, string uname, string pword)
        {
            string connectionString = new System.Data.EntityClient.EntityConnectionStringBuilder
            {
                Metadata = "res://*",
                Provider = "System.Data.SqlClient",
                ProviderConnectionString = new System.Data.SqlClient.SqlConnectionStringBuilder
                {
                    InitialCatalog = database,
                    DataSource = server,
                    IntegratedSecurity = false,
                    UserID = uname,
                    Password = pword
                }.ConnectionString
            }.ConnectionString;

            return connectionString;
        }
    }
}
