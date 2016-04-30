using Realm.Data;
using Realm.Entity.Interfaces;

namespace Realm.Command
{
    public class TargetResult
    {
        public string FirstParameter { get; set; }
        public string SecondParameter { get; set; }
        public int Quantity { get; set; }
        public IGameEntity FoundEntity { get; set; }
        public IGameEntity FoundEntityLocation { get; set; }
        public Globals.EntityLocationTypes FoundEntityLocationType { get; set; }
    }
}