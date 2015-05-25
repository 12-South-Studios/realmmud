using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using Realm.DAL.Common;
using Realm.Live.DAL.Interfaces;
using Realm.Live.DAL.Models;

namespace Realm.Live.DAL.Migrations
{
    public sealed class Configuration : DbMigrationsConfiguration<RealmLiveDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(RealmLiveDbContext context)
        {
            try
            {
                SeedChannels(context);
            }
            catch (Exception ex)
            {
                
            }
        }

        private void SeedChannels(IRealmLiveDbContext context)
        {
            foreach (var key in _channelTable.Keys)
            {
                var values = _channelTable[key];

                context.Channels.AddOrUpdate(x => x.Id, new Channel
                {
                    Id = key,
                    Name = (string) values[0],
                    ChannelType = (ChannelTypes) values[1],
                    Bits = (int) values[2]
                });
            }
        }

        private readonly Dictionary<int, List<object>> _channelTable = new Dictionary
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