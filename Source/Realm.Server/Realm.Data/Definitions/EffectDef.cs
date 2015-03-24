using System.Collections.Generic;
using Realm.Library.Common;
using Realm.Library.Common.Data;

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

        public string DisplayName
        {
            get { return Def.GetString("DisplayName"); }
        }

        public string DisplayDescription
        {
            get { return Def.GetString("DisplayDescription"); }
        }

        public Globals.Globals.EffectTypes EffectType
        {
            get { return EnumerationExtensions.GetEnum<Globals.Globals.EffectTypes>(Def.GetInt("EffectTypeID")); }
        }

        public int Duration
        {
            get { return Def.GetInt("Duration"); }
        }

        public Globals.Globals.Statistics ResistStatistic
        {
            get { return EnumerationExtensions.GetEnum<Globals.Globals.Statistics>(Def.GetInt("ResistStatisticID")); }
        }

        public EffectDef OnFailEffect
        {
            get
            {
                return
                    (EffectDef)
                    StaticDataManager.GetStaticData(Globals.Globals.SystemTypes.Effect,
                                                             Def.GetString("OnFailEffectID"));
            }
        }

        public EffectDef OnResistEffect
        {
            get
            {
                return
                    (EffectDef)
                    StaticDataManager.GetStaticData(Globals.Globals.SystemTypes.Effect,
                                                             Def.GetString("OnResistEffectID"));
            }
        }

        public int TagSetID
        {
            get { return Def.GetInt("TagSetID"); }
        }

        public int MovementModeBits
        {
            get { return Def.GetInt("MovementModeBitField"); }
        }

        public string ApplicationTextSelf
        {
            get { return Def.GetString("ApplicationTextSelf"); }
        }

        public string ApplicationTextOther
        {
            get { return Def.GetString("ApplicationTextOther"); }
        }

        public string FadeTextSelf
        {
            get { return Def.GetString("FadeTextSelf"); }
        }

        public string FadeTextOther
        {
            get { return Def.GetString("FadeTextOther"); }
        }

        public bool IsRemoveable
        {
            get { return Globals.Globals.EffectBits.IsRemoveable.HasBit(Def.GetInt("Bits")); }
        }

        public bool IsTavern
        {
            get { return Globals.Globals.EffectBits.IsTavern.HasBit(Def.GetInt("Bits")); }
        }

        public bool IsSafe
        {
            get { return Globals.Globals.EffectBits.IsSafe.HasBit(Def.GetInt("Bits")); }
        }

        public bool OnEnter
        {
            get { return Globals.Globals.EffectBits.OnEnter.HasBit(Def.GetInt("Bits")); }
        }

        public bool OnTurn
        {
            get { return Globals.Globals.EffectBits.OnTurn.HasBit(Def.GetInt("Bits")); }
        }

        public IEnumerable<Atom> DynamicZones
        {
            get { return Def.GetAtom<ListAtom>("DynamicZones"); }
        }

        public IEnumerable<Atom> HealthChanges
        {
            get { return Def.GetAtom<ListAtom>("HealthChanges"); }
        }

        public IEnumerable<Atom> Positions
        {
            get { return Def.GetAtom<ListAtom>("Positions"); }
        }

        public IEnumerable<Atom> Primitives
        {
            get { return Def.GetAtom<ListAtom>("Primitives"); }
        }

        public IEnumerable<Atom> StatMods
        {
            get { return Def.GetAtom<ListAtom>("StatMods"); }
        }
    }
}