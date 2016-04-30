using Realm.Data;

namespace Realm.Pathing.Core
{
    public class Edge
    {
        public long Destination { get; set; }

        public int Cost { get; set; }

        public Globals.Directions Direction { get; set; }
    }
}