using System.Collections.Generic;
using Realm.Library.Common.Data;
using Realm.Library.Common.Extensions;

namespace Realm.Data.Definitions
{
    /// <summary>
    ///
    /// </summary>
    public class SpaceDef : Definition
    {
        /// <summary>
        ///
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="definition"></param>
        public SpaceDef(long id, string name, DictionaryAtom definition)
            : base(id, name, definition)
        {
        }

        /// <summary>
        ///
        /// </summary>
        public TerrainDef Terrain => (TerrainDef)
            StaticDataManager.GetStaticData(Globals.SystemTypes.Terrain,
                Def.GetString("TerrainID"));

        /// <summary>
        ///
        /// </summary>
        public int AccessLevel => Def.GetInt("AccessLevel");

        /// <summary>
        ///
        /// </summary>
        public int TagSetID => Def.GetInt("TagSetID");

        /// <summary>
        ///
        /// </summary>
        public string DisplayName => Def.GetString("DisplayName");

        /// <summary>
        ///
        /// </summary>
        public string DisplayDescription => Def.GetString("DisplayDescription");

        /// <summary>
        ///
        /// </summary>
        public IEnumerable<Atom> Portals => Def.GetAtom<ListAtom>("Portals");

        /// <summary>
        ///
        /// </summary>
        public bool NoMobAllowed => Globals.SpaceBits.NoMobAllowed.HasBit(Def.GetInt("Bits"));

        /// <summary>
        ///
        /// </summary>
        public bool NoRecall => Globals.SpaceBits.NoRecall.HasBit(Def.GetInt("Bits"));

        /// <summary>
        ///
        /// </summary>
        public bool NoSummon => Globals.SpaceBits.NoSummon.HasBit(Def.GetInt("Bits"));

        /// <summary>
        ///
        /// </summary>
        public bool IsSafe => Globals.SpaceBits.IsSafe.HasBit(Def.GetInt("Bits"));

        /// <summary>
        ///
        /// </summary>
        public bool NoMagic => Globals.SpaceBits.NoMagic.HasBit(Def.GetInt("Bits"));

        /// <summary>
        ///
        /// </summary>
        public bool IsShrine => Globals.SpaceBits.IsShrine.HasBit(Def.GetInt("Bits"));

        /// <summary>
        ///
        /// </summary>
        public bool IsTavern => Globals.SpaceBits.IsTavern.HasBit(Def.GetInt("Bits"));

        /// <summary>
        ///
        /// </summary>
        public bool IsDynamic => Globals.SpaceBits.IsDynamic.HasBit(Def.GetInt("Bits"));

        /// <summary>
        ///
        /// </summary>
        public bool AllowDynamic => Globals.SpaceBits.AllowDynamic.HasBit(Def.GetInt("Bits"));
    }
}