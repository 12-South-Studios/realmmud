using System.Collections.Generic;
using Realm.Library.Common.Data;
using Realm.Library.Common.Extensions;

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
        public string DisplayName => Def.GetString("DisplayName");

        /// <summary>
        ///
        /// </summary>
        public string DisplayDescription => Def.GetString("DisplayDescription");

        public Globals.SizeTypes SizeType => EnumerationExtensions.GetEnum<Globals.SizeTypes>(Def.GetInt("SizeTypeID"));

        public Globals.MobileTypes MobileType => EnumerationExtensions.GetEnum<Globals.MobileTypes>(Def.GetInt("MobileTypeID"));

        public RaceDef Race => (RaceDef)
            StaticDataManager.GetStaticData(Globals.SystemTypes.Race, Def.GetString("RaceID"));

        public int ConversationID => Def.GetInt("ConversationID");

        public int AccessLevel => Def.GetInt("AccessLevel");

        public Globals.GenderTypes GenderType => EnumerationExtensions.GetEnum<Globals.GenderTypes>(Def.GetInt("GenderTypeID"));

        public int Level => Def.GetInt("Level");

        public FactionDef Faction => (FactionDef)
            StaticDataManager.GetStaticData(Globals.SystemTypes.Faction,
                Def.GetString("FactionID"));

        public int TagSetID => Def.GetInt("TagSetID");

        public bool IsHarvestable => Globals.MobileBits.IsHarvestable.HasBit(Def.GetInt("Bits"));

        public bool IsTrainer => Globals.MobileBits.IsTrainer.HasBit(Def.GetInt("Bits"));

        public bool IsPostman => Globals.MobileBits.IsPostman.HasBit(Def.GetInt("Bits"));

        public bool IsMerchant => Globals.MobileBits.IsMerchant.HasBit(Def.GetInt("Bits"));

        public bool IsCoroner => Globals.MobileBits.IsCoroner.HasBit(Def.GetInt("Bits"));

        public bool IsBanker => Globals.MobileBits.IsBanker.HasBit(Def.GetInt("Bits"));

        public bool IsBlacksmith => Globals.MobileBits.IsBlacksmith.HasBit(Def.GetInt("Bits"));

        public bool IsHealer => Globals.MobileBits.IsHealer.HasBit(Def.GetInt("Bits"));

        public bool IsAuctioneer => Globals.MobileBits.IsAuctioneer.HasBit(Def.GetInt("Bits"));

        public bool NoSummon => Globals.MobileBits.NoSummon.HasBit(Def.GetInt("Bits"));

        public bool NoAttack => Globals.MobileBits.NoAttack.HasBit(Def.GetInt("Bits"));

        public bool NoCharm => Globals.MobileBits.NoCharm.HasBit(Def.GetInt("Bits"));

        public bool NoBash => Globals.MobileBits.NoBash.HasBit(Def.GetInt("Bits"));

        public bool NoBlind => Globals.MobileBits.NoBlind.HasBit(Def.GetInt("Bits"));

        public IEnumerable<Atom> Abilities => Def.GetAtom<ListAtom>("Abilities");

        public IEnumerable<Atom> Equipment => Def.GetAtom<ListAtom>("Equipment");

        public IEnumerable<Atom> MudProgs => Def.GetAtom<ListAtom>("MudProgs");

        public DictionaryAtom Regular => Def.GetAtom<DictionaryAtom>("Regular");

        public DictionaryAtom Resource => Def.GetAtom<DictionaryAtom>("Resource");

        public IEnumerable<Atom> Statistics => Def.GetAtom<ListAtom>("Statistics");

        public IEnumerable<Atom> Treasures => Def.GetAtom<ListAtom>("Treasures");

        public IEnumerable<Atom> TreasureTables => Def.GetAtom<ListAtom>("TreasureTables");

        public DictionaryAtom Vendor => Def.GetAtom<DictionaryAtom>("Vendor");
    }
}