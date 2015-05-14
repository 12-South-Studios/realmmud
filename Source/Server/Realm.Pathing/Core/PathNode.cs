using Realm.Entity.Entities;

namespace Realm.Pathing.Core
{
    public class PathNode
    {
        public PathNode(Space destination, string step)
        {
            Destination = destination;
            Step = step;
        }

        public Space Destination { get; private set; }

        public string Step { get; private set; }
    }
}