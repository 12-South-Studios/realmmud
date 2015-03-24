using System.Collections.Generic;
using System.Linq;
using Realm.Library.Common;
using Realm.Library.Common.Data;

namespace Realm.Data.Definitions
{
    /// <summary>
    /// Definition of an Archetype
    /// </summary>
    public class ArchetypeDef : Definition
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public ArchetypeDef(long id, string name, DictionaryAtom definition)
            : base(id, name, definition)
        {
        }

        public string DisplayName { get { return Def.GetString("DisplayName"); } }

        public string DisplayDescription
        {
            get { return Def.GetString("DisplayDescription"); }
        }

        public int TagSet
        {
            get { return Def.GetInt("TagSetID"); }
        }

        private List<ArchetypeAbilityDef> _abilities;

        public IEnumerable<ArchetypeAbilityDef> Abilities
        {
            get
            {
                if (_abilities.IsNull())
                {
                    _abilities = new List<ArchetypeAbilityDef>();
                    foreach (var abilityDef in Def.GetAtom<ListAtom>("Abilities")
                        .Select(atom => atom.CastAs<DictionaryAtom>())
                        .Select(abilityDef => new ArchetypeAbilityDef(abilityDef.GetInt("ArchetypeAbilityMapID"), abilityDef)))
                    {
                        _abilities.Add(abilityDef);
                    }
                }
                return _abilities;
            }
        }

        private List<ArchetypeSkillCategoryDef> _skillCategories;

        public IEnumerable<ArchetypeSkillCategoryDef> SkillCategories
        {
            get
            {
                if (_abilities.IsNull())
                {
                    _skillCategories = new List<ArchetypeSkillCategoryDef>();
                    foreach (var abilityDef in Def.GetAtom<ListAtom>("SkillCategories")
                        .Select(atom => atom.CastAs<DictionaryAtom>())
                        .Select(abilityDef => new ArchetypeSkillCategoryDef(abilityDef.GetInt("ArchetypeSkillCategoryMapID"), abilityDef)))
                    {
                        _skillCategories.Add(abilityDef);
                    }
                }
                return _skillCategories;
            }
        }

        private List<ArchetypeStatisticDef> _statistics;

        public IEnumerable<ArchetypeStatisticDef> Statistics
        {
            get
            {
                if (_statistics.IsNull())
                {
                    _statistics = new List<ArchetypeStatisticDef>();
                    foreach (var abilityDef in Def.GetAtom<ListAtom>("Statistics")
                        .Select(atom => atom.CastAs<DictionaryAtom>())
                        .Select(abilityDef => new ArchetypeStatisticDef(abilityDef.GetInt("ArchetypeStatisticMapID"), abilityDef)))
                    {
                        _statistics.Add(abilityDef);
                    }
                }
                return _statistics;
            }
        }
    }
}