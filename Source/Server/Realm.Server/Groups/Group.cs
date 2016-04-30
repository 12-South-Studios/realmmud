using System.Collections.Generic;
using Realm.Entity.Entities;

namespace Realm.Server.Groups

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
