using System.Collections.Generic;
using System.Linq;
using Realm.Entity.Entities;

namespace Realm.Pathing.Core
{
    public class Path
    {
        private readonly IList<PathNode> _nodes;

        public Path()
        {
            _nodes = new List<PathNode>();
        }

        public bool RemoveNode(Space space)
        {
            for (var i = 0; i < _nodes.Count; i++)
            {
                if (!Equals(_nodes[i].Destination, space)) continue;
                _nodes.RemoveAt(i);
                return true;
            }
            return false;
        }

        public PathNode GetNode(Space space)
        {
            return _nodes.FirstOrDefault(node => node.Destination == space);
        }

        public IEnumerable<PathNode> PathNodes => _nodes;

        //public bool BuildPath(Objects.Biota oMob, Objects.Space oDestination, Dijkstra.Table table)
        //{
        //    string err;
        //    Objects.Zone oZone;
        //    Objects.Space oSourceSpace, oCurrentSpace;

        //    // destination Space must be in the same zone
        //    if (oDestination.Location == oMob.Location.Location)
        //        return false;

        //    if (oDestination == oMob.Location)
        //        return false;

        //    oZone = oMob.Location.Location;
        //    oSourceSpace = oMob.Location;
        //    oCurrentSpace = oDestination;

        //    while (oSourceSpace != oCurrentSpace)
        //    {
        //        Exit e = oSourceSpace.GetExit(oCurrentSpace);
        //        string step = e.Name.ToLower()
        //        if (step == "")
        //            return false;

        //        PathNode oPathNode = new PathNode(oCurrentSpace, step);
        //        if (oPathNode.IsNull())
        //            return false;

        //        // assign the current Space counter to be the previous Space
        //        oCurrentSpace = ZoneMgr->FindSpace(Table->Results[oCurrentSpace->ID()-oZone->firstSpacenumber].Previous + oZone->firstSpacenumber);
        //        if (oCurrentSpace.IsNull())
        //            return false;

        //        m_Nodes.Add(oPathNode);
        //    }
        //    return true;
        //}
    }
}