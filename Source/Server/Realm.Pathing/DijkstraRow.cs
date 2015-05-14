namespace Realm.Pathing
{
    public class DijkstraRow
    {
        /// <summary>
        /// Total Cost from source
        /// </summary>
        public int Total { get; set; }

        /// <summary>
        /// Index of the Vertex preceeding this one
        /// </summary>
        public int Previous { get; set; }

        /// <summary>
        /// Flag used to determine if this Vertex has been visited
        /// </summary>
        public bool Visited { get; set; }
    }
}