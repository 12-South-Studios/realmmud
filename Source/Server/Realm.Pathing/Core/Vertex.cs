using System.Collections.Generic;
using Realm.Entity.Entities;

namespace Realm.Pathing.Core
{
    public class Vertex
    {
        public Space Space { get; set; }

        public List<Edge> Edges { get; set; }
    }
}