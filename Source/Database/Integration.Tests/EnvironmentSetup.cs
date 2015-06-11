using System.Configuration;
using System.Data.Entity;
using System.Data.SqlClient;
using Ninject;
using NUnit.Framework;
using Realm.Admin.DAL;
using Realm.DAL;
using Realm.Live.DAL;

namespace Integration.Tests
{
    [TestFixture]
    public class EnvironmentSetup
    {
        private static IKernel _kernel;

        [SetUp]
        public static void Initialize()
        {
            _kernel = new StandardKernel(new RealmDbContextModule(), 
                new RealmAdminDbContextModule(), new RealmLiveDbContextModule());
        }

        [TearDown]
        public static void CleanUp()
        {
            _kernel.Dispose();
        }

        [Test]
        [Category("Integration")]
        public void CreateAndInitializeDatabase_RealmAdmin()
        {
            DropDatabase("AdminDbContext");
            Database.SetInitializer(new MigrateDatabaseToLatestVersion
                <RealmAdminDbContext, Realm.Admin.DAL.Migrations.Configuration>());
            AdminDatabaseSeeder.Kernel = _kernel;
            AdminDatabaseSeeder.Seed();
        }

        [Test]
        [Category("Integration")]
        public void CreateAndInitializeDatabase_Realm()
        {
            DropDatabase("RealmDbContext");
            Database.SetInitializer(new MigrateDatabaseToLatestVersion
                <RealmDbContext, Realm.DAL.Migrations.Configuration>());
            RealmDatabaseSeeder.Kernel = _kernel;
            RealmDatabaseSeeder.Seed();
        }

        [Test]
        [Category("Integration")]
        public void CreateAndInitializeDatabase_RealmLive()
        {
            DropDatabase("LiveDbContext");
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
                catch (SqlException ex)
                {
                    return;
                }

                sqlConnection.ChangeDatabase("Master");
                var singleUserCommand = new SqlCommand(string.Format("alter database {0} set single_user with rollback immediate", databaseName),
                        sqlConnection);
                singleUserCommand.ExecuteNonQuery();

                var command = new SqlCommand(string.Format("drop database {0}", databaseName), sqlConnection);
                command.ExecuteNonQuery();
                sqlConnection.Close();
            }
        }
    }
}