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

        public string DisplayName { get { return Def.GetString("DisplayName"); } }

        public string DisplayDescription { get { return Def.GetString("DisplayDescription"); } }

        public ItemDef MagicalNode
        {
            get
            {
                return
                    (ItemDef)
                    StaticDataManager.GetStaticData(Globals.Globals.SystemTypes.Item,
                                                             Def.GetString("MagicalNodeID"));
            }
        }

        public int CastTime { get { return Def.GetInt("CastTime"); } }

        public int TagSetID { get { return Def.GetInt("TagSetID"); } }

        public IEnumerable<Atom> Effects { get { return Def.GetAtom<ListAtom>("Effects"); } }

        public IEnumerable<Atom> Participants { get { return Def.GetAtom<ListAtom>("Participants"); } }

        public IEnumerable<Atom> Reagants { get { return Def.GetAtom<ListAtom>("Reagants"); } }

        public IEnumerable<Atom> Requirements { get { return Def.GetAtom<ListAtom>("Requirements"); } }
    }
}