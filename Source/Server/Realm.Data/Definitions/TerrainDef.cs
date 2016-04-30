using System.Collections.Generic;
using Realm.Library.Common.Data;
using Realm.Library.Common.Extensions;

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

        public string DisplayName => Def.GetString("DisplayName");

        public string DisplayDescription => Def.GetString("DisplayDescription");

        public int MovementCost => Def.GetInt("MovementCost");

        public int SkillID => Def.GetInt("SkillID");

        public bool IsLitBySun => Globals.TerrainBits.IsLitBySun.HasBit(Def.GetInt("Bits"));

        public IEnumerable<Atom> Restrictions => Def.GetAtom<ListAtom>("Restrictions");
    }
}