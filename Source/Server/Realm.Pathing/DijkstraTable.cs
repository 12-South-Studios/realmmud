using System.Collections.Generic;
using Realm.Pathing.Core;

namespace Realm.Pathing
{
    public class DijkstraTable
    {
        /// <summary>
        /// The Graph of all Nodes
        /// </summary>
        public Graph Graph { get; set; }

        /// <summary>
        /// Index of the Source Vertex
        /// </summary>
        public int Source { get; set; }

        /// <summary>
        /// Table of Results
        /// </summary>
        public IList<DijkstraRow> Results { get; set; }
    }
}