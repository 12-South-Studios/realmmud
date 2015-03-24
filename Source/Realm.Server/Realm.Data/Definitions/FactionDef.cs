using System.Collections.Generic;
using Realm.Library.Common.Data;

namespace Realm.Data.Definitions
{
    /// <summary>
    /// Definition of an Archetype
    /// </summary>
    public class FactionDef : Definition
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public FactionDef(long id, string name, DictionaryAtom definition)
            : base(id, name, definition)
        {
        }

        public string DisplayName { get { return Def.GetString("DisplayName"); } }

        public int TagSetID { get { return Def.GetInt("TagSetID"); } }

        public IEnumerable<Atom> Oppositions { get { return Def.GetAtom<ListAtom>("Oppositions"); } }
    }
}