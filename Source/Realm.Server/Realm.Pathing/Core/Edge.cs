namespace Realm.Pathing.Core
{
    public class Edge
    {
        public long Destination { get; set; }

        public int Cost { get; set; }

        public Globals.Globals.Directions Direction { get; set; }
    }
}