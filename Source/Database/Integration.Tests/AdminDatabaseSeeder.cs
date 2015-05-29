using System;
using Ninject;
using Realm.Admin.DAL;
using Realm.Admin.DAL.Models;

namespace Integration.Tests
{
    public static class AdminDatabaseSeeder
    {
        public static IKernel Kernel;

        public static void Seed()
        {
            //Only seed data here that doesn't go to Dev.  Don't seed lookup data.  Just fake stuff.
            AddRestrictedNames();
        }

        private static void AddRestrictedNames()
        {
            using (var dbContext = Kernel.Get<IRealmAdminDbContext>())
            {
                dbContext.RestrictedNames.Add(new RestrictedName
                {
                    CreateDateUtc = DateTime.UtcNow,
                    IsCopyright = true,
                    IsProfanity = false,
                    IsRegex = false,
                    IsReserved = false,
                    Value = "Gandalf"
                });
                dbContext.RestrictedNames.Add(new RestrictedName
                {
                    CreateDateUtc = DateTime.UtcNow,
                    IsCopyright = false,
                    IsProfanity = false,
                    IsRegex = false,
                    IsReserved = true,
                    Value = "AmonGwareth"
                });
                dbContext.SaveChanges();
            }
        }
    
    }
}
