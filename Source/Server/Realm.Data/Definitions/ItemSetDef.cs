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

        public string DisplayName => Def.GetString("DisplayName");

        public string DisplayDescription => Def.GetString("DisplayDescription");

        public IEnumerable<Atom> Bonuses => Def.GetAtom<ListAtom>("Bonuses");

        public IEnumerable<Atom> Items => Def.GetAtom<ListAtom>("Items");
    }
}