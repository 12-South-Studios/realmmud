using System.Collections.Generic;
using Realm.Library.Common;
using Realm.Library.Common.Data;

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
        public TerrainDef Terrain
        {
            get
            {
                return
                    (TerrainDef)
                    StaticDataManager.GetStaticData(Globals.Globals.SystemTypes.Terrain,
                                                             Def.GetString("TerrainID"));
            }
        }

        /// <summary>
        ///
        /// </summary>
        public int AccessLevel { get { return Def.GetInt("AccessLevel"); } }

        /// <summary>
        ///
        /// </summary>
        public int TagSetID { get { return Def.GetInt("TagSetID"); } }

        /// <summary>
        ///
        /// </summary>
        public string DisplayName { get { return Def.GetString("DisplayName"); } }

        /// <summary>
        ///
        /// </summary>
        public string DisplayDescription { get { return Def.GetString("DisplayDescription"); } }

        /// <summary>
        ///
        /// </summary>
        public IEnumerable<Atom> Portals
        {
            get { return Def.GetAtom<ListAtom>("Portals"); }
        }

        /// <summary>
        ///
        /// </summary>
        public bool NoMobAllowed
        {
            get { return Globals.Globals.SpaceBits.NoMobAllowed.HasBit(Def.GetInt("Bits")); }
        }

        /// <summary>
        ///
        /// </summary>
        public bool NoRecall
        {
            get { return Globals.Globals.SpaceBits.NoRecall.HasBit(Def.GetInt("Bits")); }
        }

        /// <summary>
        ///
        /// </summary>
        public bool NoSummon
        {
            get { return Globals.Globals.SpaceBits.NoSummon.HasBit(Def.GetInt("Bits")); }
        }

        /// <summary>
        ///
        /// </summary>
        public bool IsSafe
        {
            get { return Globals.Globals.SpaceBits.IsSafe.HasBit(Def.GetInt("Bits")); }
        }

        /// <summary>
        ///
        /// </summary>
        public bool NoMagic
        {
            get { return Globals.Globals.SpaceBits.NoMagic.HasBit(Def.GetInt("Bits")); }
        }

        /// <summary>
        ///
        /// </summary>
        public bool IsShrine
        {
            get { return Globals.Globals.SpaceBits.IsShrine.HasBit(Def.GetInt("Bits")); }
        }

        /// <summary>
        ///
        /// </summary>
        public bool IsTavern
        {
            get { return Globals.Globals.SpaceBits.IsTavern.HasBit(Def.GetInt("Bits")); }
        }

        /// <summary>
        ///
        /// </summary>
        public bool IsDynamic
        {
            get { return Globals.Globals.SpaceBits.IsDynamic.HasBit(Def.GetInt("Bits")); }
        }

        /// <summary>
        ///
        /// </summary>
        public bool AllowDynamic
        {
            get { return Globals.Globals.SpaceBits.AllowDynamic.HasBit(Def.GetInt("Bits")); }
        }
    }
}