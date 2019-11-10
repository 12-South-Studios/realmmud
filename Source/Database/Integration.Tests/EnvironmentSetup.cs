using System.Configuration;
using System.Data.Entity;
using System.Data.SqlClient;
using Ninject;
using Realm.Admin.DAL;
using Realm.DAL;
using Realm.Live.DAL;
using Xunit;

namespace Integration.Tests
{
    public class EnvironmentSetup
    {
        private static IKernel _kernel;

        public EnvironmentSetup()
        {
            _kernel = new StandardKernel(new RealmDbContextModule(), 
                new RealmAdminDbContextModule(), new RealmLiveDbContextModule());
        }

        ~EnvironmentSetup()
        {
            _kernel.Dispose();
        }

        [Fact]
        [Trait("Category", "Integration")]
        public void CreateAndInitializeDatabase_RealmAdmin()
        {
           // DropDatabase("AdminDbContext");
            Database.SetInitializer(new MigrateDatabaseToLatestVersion
                <RealmAdminDbContext, Realm.Admin.DAL.Migrations.Configuration>());
            AdminDatabaseSeeder.Kernel = _kernel;
            AdminDatabaseSeeder.Seed();
        }

        [Fact]
        [Trait("Category", "Integration")]
        public void CreateAndInitializeDatabase_Realm()
        {
           // DropDatabase("RealmDbContext");
            Database.SetInitializer(new MigrateDatabaseToLatestVersion
                <RealmDbContext, Realm.DAL.Migrations.Configuration>());
            RealmDatabaseSeeder.Kernel = _kernel;
            RealmDatabaseSeeder.Seed();
        }

        [Fact]
        [Trait("Category", "Integration")]
        public void CreateAndInitializeDatabase_RealmLive()
        {
           // DropDatabase("LiveDbContext");
            Database.SetInitializer(new MigrateDatabaseToLatestVersion
                <RealmLiveDbContext, Realm.Live.DAL.Migrations.Configuration>());
            LiveDatabaseSeeder.Kernel = _kernel;
            LiveDatabaseSeeder.Seed();
        }

        private static void DropDatabase(string connectionStringName)
        {
            var connectionString = ConfigurationManager.ConnectionStrings[connectionStringName].ToString();
            var builder = new SqlConnectionStringBuilder(connectionString);
            var databaseName = builder.InitialCatalog;

            using (var sqlConnection = new SqlConnection(connectionString))
            {
                try
                {
                    sqlConnection.Open();
                }
                catch (SqlException)
                {
                    return;
                }

                sqlConnection.ChangeDatabase("Master");
                var singleUserCommand = new SqlCommand(
                    $"alter database {databaseName} set single_user with rollback immediate",
                        sqlConnection);
                singleUserCommand.ExecuteNonQuery();

                var command = new SqlCommand($"drop database {databaseName}", sqlConnection);
                command.ExecuteNonQuery();
                sqlConnection.Close();
            }
        }
    }
}