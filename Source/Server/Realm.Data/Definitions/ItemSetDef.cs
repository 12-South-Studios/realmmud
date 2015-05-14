using System.Collections.Generic;
using Realm.Library.Common.Data;

namespace Realm.Data.Definitions
{
    /// <summary>
    /// Definition of an Archetype
    /// </summary>
    public class ItemSetDef : Definition
    {
        /// <summary>
        /// L
        /// </summary>
        public ItemSetDef(long id, string name, DictionaryAtom definition)
            : base(id, name, definition)
        {
        }

        public string DisplayName { get { return Def.GetString("DisplayName"); } }

        public string DisplayDescription { get { return Def.GetString("DisplayDescription"); } }

        public IEnumerable<Atom> Bonuses
        {
            get { return Def.GetAtom<ListAtom>("Bonuses"); }
        }

        public IEnumerable<Atom> Items
        {
            get { return Def.GetAtom<ListAtom>("Items"); }
        }
    }
}