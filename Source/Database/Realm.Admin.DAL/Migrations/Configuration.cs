using System;
using System.Data.Entity.Migrations;

namespace Realm.Admin.DAL.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<RealmAdminDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(RealmAdminDbContext context)
        {
            try
            {
            }
            catch (Exception ex)
            {
                
            }
        }
    }
}