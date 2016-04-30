using System.Collections.Generic;
using Realm.Library.Common.Data;
using Realm.Library.Common.Extensions;

namespace Realm.Data.Definitions
{
    /// <summary>
    /// Definition of an Effect
    /// </summary>
    public class EffectDef : Definition
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public EffectDef(long id, string name, DictionaryAtom definition)
            : base(id, name, definition)
        {
        }

        public string DisplayName => Def.GetString("DisplayName");

        public string DisplayDescription => Def.GetString("DisplayDescription");

        public Globals.EffectTypes EffectType => EnumerationExtensions.GetEnum<Globals.EffectTypes>(Def.GetInt("EffectTypeID"));

        public int Duration => Def.GetInt("Duration");

        public Globals.Statistics ResistStatistic => EnumerationExtensions.GetEnum<Globals.Statistics>(Def.GetInt("ResistStatisticID"));

        public EffectDef OnFailEffect => (EffectDef)
            StaticDataManager.GetStaticData(Globals.SystemTypes.Effect,
                Def.GetString("OnFailEffectID"));

        public EffectDef OnResistEffect => (EffectDef)
            StaticDataManager.GetStaticData(Globals.SystemTypes.Effect,
                Def.GetString("OnResistEffectID"));

        public int TagSetID => Def.GetInt("TagSetID");

        public int MovementModeBits => Def.GetInt("MovementModeBitField");

        public string ApplicationTextSelf => Def.GetString("ApplicationTextSelf");

        public string ApplicationTextOther => Def.GetString("ApplicationTextOther");

        public string FadeTextSelf => Def.GetString("FadeTextSelf");

        public string FadeTextOther => Def.GetString("FadeTextOther");

        public bool IsRemoveable => Globals.EffectBits.IsRemoveable.HasBit(Def.GetInt("Bits"));

        public bool IsTavern => Globals.EffectBits.IsTavern.HasBit(Def.GetInt("Bits"));

        public bool IsSafe => Globals.EffectBits.IsSafe.HasBit(Def.GetInt("Bits"));

        public bool OnEnter => Globals.EffectBits.OnEnter.HasBit(Def.GetInt("Bits"));

        public bool OnTurn => Globals.EffectBits.OnTurn.HasBit(Def.GetInt("Bits"));

        public IEnumerable<Atom> DynamicZones => Def.GetAtom<ListAtom>("DynamicZones");

        public IEnumerable<Atom> HealthChanges => Def.GetAtom<ListAtom>("HealthChanges");

        public IEnumerable<Atom> Positions => Def.GetAtom<ListAtom>("Positions");

        public IEnumerable<Atom> Primitives => Def.GetAtom<ListAtom>("Primitives");

        public IEnumerable<Atom> StatMods => Def.GetAtom<ListAtom>("StatMods");
    }
}