using Realm.Library.Common;

namespace Realm.Entity
{
    /// <summary>
    /// Class that represents a Flag or descriptor of a Game Object
    /// </summary>
    public class Flag : Cell
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Flag"/> class.
        /// </summary>
        /// <param name="id">ID of the Flag</param>
        /// <param name="name">Name of the Flag</param>
        /// <param name="abbrev">Abbreviation of the Flag</param>
        /// <param name="canReset">Value indicating whether or not the Flag can be reset</param>
        public Flag(long id, string name, string abbrev, bool canReset)
        {
            Abbrev = abbrev;
            CanReset = canReset;
            ID = id;
            Name = name;
        }

        /// <summary>
        /// Gets the abbreviation of the flag
        /// </summary>
        public string Abbrev { get; private set; }

        /// <summary>
        /// Gets a value indicating whether or not the flag can be reset
        /// </summary>
        public bool CanReset { get; private set; }
    }
}