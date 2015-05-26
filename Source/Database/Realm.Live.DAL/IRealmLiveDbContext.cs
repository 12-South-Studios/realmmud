using System;
using System.Data.Entity;
using Realm.DAL.Common;
using Realm.Live.DAL.Models;

namespace Realm.Live.DAL
{
    public interface IRealmLiveDbContext : IDisposable, IRealmContext
    {
        IDbSet<Auction> Auctions { get; set; }
        IDbSet<Channel> Channels { get; set; }
        IDbSet<Character> Characters { get; set; }
        IDbSet<GameState> GameStates { get; set; }
        IDbSet<Guild> Guilds { get; set; }
        IDbSet<Instance> Instances { get; set; }
        IDbSet<Property> Properties { get; set; }
        IDbSet<User> Users { get; set; }

        string GenerateSalt();
    }
}
