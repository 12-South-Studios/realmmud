using System.Collections.Generic;
using System.Linq;
using Realm.Data.Definitions.Ability;
using Realm.Data.Definitions.Common;
using Realm.Library.Common.Data;
using Realm.Library.Common.Extensions;
using Realm.Library.Common.Objects;

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

        public string DisplayName => Def.GetString("DisplayName");

        public string DisplayDescription => Def.GetString("DisplayDescription");

        public int ManaCost => Def.GetInt("ManaCost");

        public int StaminaCost => Def.GetInt("StaminaCost");

        public double PreDelay => Def.GetReal("PreDelay");

        public double PostDelay => Def.GetReal("PostDelay");

        public Globals.Statistics OffensiveStat => EnumerationExtensions.GetEnum<Globals.Statistics>(Def.GetInt("OffensiveStatID"));

        public Globals.Statistics DefensiveStat => EnumerationExtensions.GetEnum<Globals.Statistics>(Def.GetInt("DefensiveStatID"));

        public TerrainDef Terrain => (TerrainDef)StaticDataManager.GetStaticData(Globals.SystemTypes.Terrain, Def.GetString("TerrainID"));

        public int TagSetID => Def.GetInt("TagSetID");

        public SkillDef InterruptionResistSkill => (SkillDef)
            StaticDataManager.GetStaticData(Globals.SystemTypes.Skill,
                Def.GetString("InterruptionResistSkillID"));

        public EffectDef InterruptionEffect => (EffectDef)
            StaticDataManager.GetStaticData(Globals.SystemTypes.Effect,
                Def.GetString("InterruptionEffectID"));

        public int RechargeRate => Def.GetInt("RechargeRate");

        public Globals.TargetClassTypes TargetClass => EnumerationExtensions.GetEnum<Globals.TargetClassTypes>(Def.GetInt("TargetClassTypeID"));

        public string PluralName => Def.GetString("PluralName");

        public string VerbalText => Def.GetString("VerbalText");

        public string BeginUseText => Def.GetString("BeginUseText");

        public string UseText => Def.GetString("UseText");

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