using System.Collections.Generic;
using System.Data.Entity.Migrations;
using Ninject;
using Realm.DAL.Common;
using Realm.Live.DAL;
using Realm.Live.DAL.Models;

namespace Integration.Tests
{
    public static class LiveDatabaseSeeder
    {
        public static IKernel Kernel;

        public static void Seed()
        {
            //Only seed data here that doesn't go to Dev.  Don't seed lookup data.  Just fake stuff.
            AddChannels();

        }

        private static void AddChannels()
        {
            using (var dbContext = Kernel.Get<IRealmLiveDbContext>())
            {
                foreach (var key in ChannelTable.Keys)
                {
                    var values = ChannelTable[key];

                    dbContext.Channels.AddOrUpdate(x => x.Id, new Channel
                    {
                        Id = key,
                        Name = (string) values[0],
                        ChannelType = (ChannelTypes) values[1],
                        Bits = (int) values[2]
                    });
                }
                dbContext.SaveChanges();
            }
        }

        private static readonly Dictionary<int, List<object>> ChannelTable = new Dictionary
            <int, List<object>>
        {
            {1, new List<object> {"Error", ChannelTypes.System, 3}},
            {2, new List<object> {"Debug", ChannelTypes.System, 3}},
            {3, new List<object> {"Wizard", ChannelTypes.System, 4}},
            {4, new List<object> {"Builder", ChannelTypes.System, 8}},
            {5, new List<object> {"General", ChannelTypes.System, 16}},
            {6, new List<object> {"Marketplace", ChannelTypes.System, 16}},
            {7, new List<object> {"OOC", ChannelTypes.Player, 16}}
        };
    }
}
