using Realm.Library.Common.Objects;

namespace Realm.Entity
{
    /// <summary>
    /// Tag object for the MUD
    /// </summary>
    public class Tag : Cell
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Tag"/> class
        /// </summary>
        /// <param name="id">ID of the tag</param>
        /// <param name="name">Name of the tag</param>
        public Tag(long id, string name)
        {
            ID = id;
            Name = name;
        }
    }
}