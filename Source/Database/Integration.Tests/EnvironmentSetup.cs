using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
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

        private static IEnumerable<string> ExcludeDatabases
        {
            get { return ConfigurationManager.AppSettings["ExcludeDatabaseServers"].Split(','); }
        }

        [SetUp]
        public static void Initialize()
        {
            _kernel = new StandardKernel();
            _kernel.Bind<IRealmDbContext>().To<RealmDbContext>();
            _kernel.Bind<IRealmLiveDbContext>().To<RealmLiveDbContext>();
            _kernel.Bind<IRealmAdminDbContext>().To<RealmAdminDbContext>();
        }

        [TearDown]
        public static void CleanUp()
        {
            _kernel.Dispose();
        }

        [Test]
        [Category("Integration")]
        public void CreateAndInitializeDatabase()
        {
            DropDatabase("Realm");
            Database.SetInitializer(new MigrateDatabaseToLatestVersion
                <RealmDbContext, Realm.DAL.Migrations.Configuration>());
            AdminDatabaseSeeder.Kernel = _kernel;
            AdminDatabaseSeeder.Seed();

            DropDatabase("Admin");
            Database.SetInitializer(new MigrateDatabaseToLatestVersion
                <RealmAdminDbContext, Realm.Admin.DAL.Migrations.Configuration>());
            RealmDatabaseSeeder.Kernel = _kernel;
            RealmDatabaseSeeder.Seed();

            DropDatabase("Live");
            Database.SetInitializer(new MigrateDatabaseToLatestVersion
                <RealmLiveDbContext, Realm.Live.DAL.Migrations.Configuration>());
            LiveDatabaseSeeder.Kernel = _kernel;
            LiveDatabaseSeeder.Seed();
        }

        private static void DropDatabase(string connectionStringName)
        {
            var connectionString = ConfigurationManager.ConnectionStrings[connectionStringName].ToString();

            if (ExcludeDatabases.Any(connectionString.Contains))
                throw new InvalidOperationException("Umm what are you doing?  Unit tests are for local databases.");

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