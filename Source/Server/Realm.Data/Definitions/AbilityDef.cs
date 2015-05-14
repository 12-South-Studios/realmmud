using System.Collections.Generic;
using System.Linq;
using Ninject;
using Realm.Data.Interfaces;
using Realm.Library.Common;
using Realm.Library.Common.Data;

namespace Realm.Data.Definitions
{
    /// <summary>
    /// Definition of an Ability
    /// </summary>
    public class AbilityDef : Definition
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public AbilityDef(long id, string name, DictionaryAtom definition)
            : base(id, name, definition)
        {
        }

        public string DisplayName { get { return Def.GetString("DisplayName"); } }

        public string DisplayDescription { get { return Def.GetString("DisplayDescription"); } }

        public int ManaCost
        {
            get { return Def.GetInt("ManaCost"); }
        }

        public int StaminaCost
        {
            get { return Def.GetInt("StaminaCost"); }
        }

        public double PreDelay
        {
            get { return Def.GetReal("PreDelay"); }
        }

        public double PostDelay
        {
            get { return Def.GetReal("PostDelay"); }
        }

        public Globals.Globals.Statistics OffensiveStat
        {
            get { return EnumerationExtensions.GetEnum<Globals.Globals.Statistics>(Def.GetInt("OffensiveStatID")); }
        }

        public Globals.Globals.Statistics DefensiveStat
        {
            get { return EnumerationExtensions.GetEnum<Globals.Globals.Statistics>(Def.GetInt("DefensiveStatID")); }
        }

        public TerrainDef Terrain
        {
            get
            {
                
                return (TerrainDef)StaticDataManager.GetStaticData(Globals.Globals.SystemTypes.Terrain, Def.GetString("TerrainID"));
            }
        }

        public int TagSetID
        {
            get { return Def.GetInt("TagSetID"); }
        }

        public SkillDef InterruptionResistSkill
        {
            get
            {
                return
                    (SkillDef)
                    StaticDataManager.GetStaticData(Globals.Globals.SystemTypes.Skill,
                                                             Def.GetString("InterruptionResistSkillID"));
            }
        }

        public EffectDef InterruptionEffect
        {
            get
            {
                return
                    (EffectDef)
                    StaticDataManager.GetStaticData(Globals.Globals.SystemTypes.Effect,
                                                             Def.GetString("InterruptionEffectID"));
            }
        }

        public int RechargeRate
        {
            get { return Def.GetInt("RechargeRate"); }
        }

        public Globals.Globals.TargetClassTypes TargetClass
        {
            get { return EnumerationExtensions.GetEnum<Globals.Globals.TargetClassTypes>(Def.GetInt("TargetClassTypeID")); }
        }

        public string PluralName
        {
            get { return Def.GetString("PluralName"); }
        }

        public string VerbalText
        {
            get { return Def.GetString("VerbalText"); }
        }

        public string BeginUseText
        {
            get { return Def.GetString("BeginUseText"); }
        }

        public string UseText
        {
            get { return Def.GetString("UseText"); }
        }

        private List<AbilityEffectDef> _effects;

        public IEnumerable<AbilityEffectDef> Effects
        {
            get
            {
                if (_effects.IsNull())
                {
                    _effects = new List<AbilityEffectDef>();
                    foreach (var effectDef in Def.GetAtom<ListAtom>("Effects")
                        .Select(atom => atom.CastAs<DictionaryAtom>())
                        .Select(effectAtom => new AbilityEffectDef(effectAtom.GetInt("AbilityEffectMapID"), effectAtom)))
                    {
                        _effects.Add(effectDef);
                    }
                }
                return _effects;
            }
        }

        private List<PrerquisitesDef> _prerequisites;

        public IEnumerable<PrerquisitesDef> Prerequisites
        {
            get
            {
                if (_prerequisites.IsNull())
                {
                    _prerequisites = new List<PrerquisitesDef>();
                    foreach (var prerequisiteDef in Def.GetAtom<ListAtom>("Prerequisites")
                        .Select(atom => atom.CastAs<DictionaryAtom>())
                        .Select(prerequisiteAtom => new PrerquisitesDef(prerequisiteAtom.GetInt("AbilityPrerequisiteMapID"), prerequisiteAtom)))
                    {
                        _prerequisites.Add(prerequisiteDef);
                    }
                }
                return _prerequisites;
            }
        }

        private List<AbilityReagantDef> _reagants;

        public IEnumerable<AbilityReagantDef> Reagants
        {
            get
            {
                if (_reagants.IsNull())
                {
                    _reagants = new List<AbilityReagantDef>();
                    foreach (var reagantDef in Def.GetAtom<ListAtom>("Reagants")
                        .Select(atom => atom.CastAs<DictionaryAtom>())
                        .Select(reagantAtom => new AbilityReagantDef(reagantAtom.GetInt("AbilityReagantMapID"), reagantAtom)))
                    {
                        _reagants.Add(reagantDef);
                    }
                }
                return _reagants;
            }
        }
    }
}