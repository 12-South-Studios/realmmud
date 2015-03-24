using System.Collections.Generic;
using Realm.Library.Common;
using Realm.Library.Common.Data;

namespace Realm.Data.Definitions
{
    /// <summary>
    ///
    /// </summary>
    public class TerrainDef : Definition
    {
        /// <summary>
        ///
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="definition"></param>
        public TerrainDef(long id, string name, DictionaryAtom definition)
            : base(id, name, definition)
        {
        }

        public string DisplayName { get { return Def.GetString("DisplayName"); } }

        public string DisplayDescription { get { return Def.GetString("DisplayDescription"); } }

        public int MovementCost { get { return Def.GetInt("MovementCost"); } }

        public int SkillID { get { return Def.GetInt("SkillID"); } }

        public bool IsLitBySun
        {
            get { return Globals.Globals.TerrainBits.IsLitBySun.HasBit(Def.GetInt("Bits")); }
        }

        public IEnumerable<Atom> Restrictions { get { return Def.GetAtom<ListAtom>("Restrictions"); } }
    }
}