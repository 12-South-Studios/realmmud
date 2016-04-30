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

        public string DisplayName => Def.GetString("DisplayName");

        public int TagSetID => Def.GetInt("TagSetID");

        public IEnumerable<Atom> Oppositions => Def.GetAtom<ListAtom>("Oppositions");
    }
}