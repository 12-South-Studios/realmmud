using System;
using System.Linq;
using Ninject;
using Realm.DAL;
using Realm.DAL.Enumerations;
using Realm.DAL.Models;

namespace Integration.Tests
{
    public static class RealmDatabaseSeeder
    {
        public static IKernel Kernel;

        public static void Seed()
        {
            //Only seed data here that doesn't go to Dev.  Don't seed lookup data.  Just fake stuff.
            AddSystemClasses();
            AddMonths();
        }

        private static void AddSystemClasses()
        {
            using (var dbContext = Kernel.Get<IRealmDbContext>())
            {
                dbContext.SystemClasses.Add(new SystemClass
                {
                    Name = "Months",
                    SystemType = SystemTypes.Month,
                    CreateDateUtc = DateTime.UtcNow
                });
                dbContext.SaveChanges();
            }
        }

        private static void AddMonths()
        {
            using (var dbContext = Kernel.Get<IRealmDbContext>())
            {
                dbContext.Months.Add(new Month
                {
                    SystemClass = dbContext.SystemClasses.First(x => x.Name == "Months"),
                    SystemName = "Month 1",
                    DisplayName = "Month One",
                    NumberDays = 30,
                    SeasonType = SeasonTypes.Fall,
                    IsShrouding = false,
                    SortOrder = 1
                });
            }
        }

     
    }
}
