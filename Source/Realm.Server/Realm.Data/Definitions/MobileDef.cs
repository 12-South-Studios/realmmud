using System.Collections.Generic;
using Realm.Library.Common;
using Realm.Library.Common.Data;

namespace Realm.Data.Definitions
{
    /// <summary>
    ///
    /// </summary>
    public class MobileDef : Definition
    {
        /// <summary>
        ///
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="definition"></param>
        public MobileDef(long id, string name, DictionaryAtom definition)
            : base(id, name, definition)
        {
        }

        /// <summary>
        ///
        /// </summary>
        public string DisplayName { get { return Def.GetString("DisplayName"); } }

        /// <summary>
        ///
        /// </summary>
        public string DisplayDescription { get { return Def.GetString("DisplayDescription"); } }

        public Globals.Globals.SizeTypes SizeType
        {
            get { return EnumerationExtensions.GetEnum<Globals.Globals.SizeTypes>(Def.GetInt("SizeTypeID")); }
        }

        public Globals.Globals.MobileTypes MobileType
        {
            get { return EnumerationExtensions.GetEnum<Globals.Globals.MobileTypes>(Def.GetInt("MobileTypeID")); }
        }

        public RaceDef Race
        {
            get
            {
                return
                    (RaceDef)
                    StaticDataManager.GetStaticData(Globals.Globals.SystemTypes.Race, Def.GetString("RaceID"));
            }
        }

        public int ConversationID { get { return Def.GetInt("ConversationID"); } }

        public int AccessLevel { get { return Def.GetInt("AccessLevel"); } }

        public Globals.Globals.GenderTypes GenderType
        {
            get { return EnumerationExtensions.GetEnum<Globals.Globals.GenderTypes>(Def.GetInt("GenderTypeID")); }
        }

        public int Level { get { return Def.GetInt("Level"); } }

        public FactionDef Faction
        {
            get
            {
                return
                    (FactionDef)
                    StaticDataManager.GetStaticData(Globals.Globals.SystemTypes.Faction,
                                                             Def.GetString("FactionID"));
            }
        }

        public int TagSetID { get { return Def.GetInt("TagSetID"); } }

        public bool IsHarvestable
        {
            get { return Globals.Globals.MobileBits.IsHarvestable.HasBit(Def.GetInt("Bits")); }
        }

        public bool IsTrainer
        {
            get { return Globals.Globals.MobileBits.IsTrainer.HasBit(Def.GetInt("Bits")); }
        }

        public bool IsPostman
        {
            get { return Globals.Globals.MobileBits.IsPostman.HasBit(Def.GetInt("Bits")); }
        }

        public bool IsMerchant
        {
            get { return Globals.Globals.MobileBits.IsMerchant.HasBit(Def.GetInt("Bits")); }
        }

        public bool IsCoroner
        {
            get { return Globals.Globals.MobileBits.IsCoroner.HasBit(Def.GetInt("Bits")); }
        }

        public bool IsBanker
        {
            get { return Globals.Globals.MobileBits.IsBanker.HasBit(Def.GetInt("Bits")); }
        }

        public bool IsBlacksmith
        {
            get { return Globals.Globals.MobileBits.IsBlacksmith.HasBit(Def.GetInt("Bits")); }
        }

        public bool IsHealer
        {
            get { return Globals.Globals.MobileBits.IsHealer.HasBit(Def.GetInt("Bits")); }
        }

        public bool IsAuctioneer
        {
            get { return Globals.Globals.MobileBits.IsAuctioneer.HasBit(Def.GetInt("Bits")); }
        }

        public bool NoSummon
        {
            get { return Globals.Globals.MobileBits.NoSummon.HasBit(Def.GetInt("Bits")); }
        }

        public bool NoAttack
        {
            get { return Globals.Globals.MobileBits.NoAttack.HasBit(Def.GetInt("Bits")); }
        }

        public bool NoCharm
        {
            get { return Globals.Globals.MobileBits.NoCharm.HasBit(Def.GetInt("Bits")); }
        }

        public bool NoBash
        {
            get { return Globals.Globals.MobileBits.NoBash.HasBit(Def.GetInt("Bits")); }
        }

        public bool NoBlind
        {
            get { return Globals.Globals.MobileBits.NoBlind.HasBit(Def.GetInt("Bits")); }
        }

        public IEnumerable<Atom> Abilities
        {
            get { return Def.GetAtom<ListAtom>("Abilities"); }
        }

        public IEnumerable<Atom> Equipment
        {
            get { return Def.GetAtom<ListAtom>("Equipment"); }
        }

        public IEnumerable<Atom> MudProgs
        {
            get { return Def.GetAtom<ListAtom>("MudProgs"); }
        }

        public DictionaryAtom Regular
        {
            get { return Def.GetAtom<DictionaryAtom>("Regular"); }
        }

        public DictionaryAtom Resource
        {
            get { return Def.GetAtom<DictionaryAtom>("Resource"); }
        }

        public IEnumerable<Atom> Statistics
        {
            get { return Def.GetAtom<ListAtom>("Statistics"); }
        }

        public IEnumerable<Atom> Treasures
        {
            get { return Def.GetAtom<ListAtom>("Treasures"); }
        }

        public IEnumerable<Atom> TreasureTables
        {
            get { return Def.GetAtom<ListAtom>("TreasureTables"); }
        }

        public DictionaryAtom Vendor
        {
            get { return Def.GetAtom<DictionaryAtom>("Vendor"); }
        }
    }
}