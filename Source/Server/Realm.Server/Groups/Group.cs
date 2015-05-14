using System.Collections.Generic;
using Realm.Entity.Entities;
using Realm.Server.NPC;

// ReSharper disable CheckNamespace
namespace Realm.Server.Players
// ReSharper restore CheckNamespace
{
    public class Group
    {
        public Group()
        {
            Members = new List<Biota>();
        }

        public Biota Leader { get; set; }
        public IList<Biota> Members { get; private set; } 
    }
}
