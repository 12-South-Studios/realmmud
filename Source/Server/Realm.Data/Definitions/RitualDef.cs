using System.Collections.Generic;
using Realm.Library.Common.Data;

namespace Realm.Data.Definitions
{
    /// <summary>
    /// Definition of an Archetype
    /// </summary>
    public class RitualDef : Definition
    {
        /// <summary>
        /// R
        /// </summary>
        public RitualDef(long id, string name, DictionaryAtom definition)
            : base(id, name, definition)
        {
        }

        public string DisplayName => Def.GetString("DisplayName");

        public string DisplayDescription => Def.GetString("DisplayDescription");

        public ItemDef MagicalNode => (ItemDef)
            StaticDataManager.GetStaticData(Globals.SystemTypes.Item,
                Def.GetString("MagicalNodeID"));

        public int CastTime => Def.GetInt("CastTime");

        public int TagSetID => Def.GetInt("TagSetID");

        public IEnumerable<Atom> Effects => Def.GetAtom<ListAtom>("Effects");

        public IEnumerable<Atom> Participants => Def.GetAtom<ListAtom>("Participants");

        public IEnumerable<Atom> Reagants => Def.GetAtom<ListAtom>("Reagants");

        public IEnumerable<Atom> Requirements => Def.GetAtom<ListAtom>("Requirements");
    }
}