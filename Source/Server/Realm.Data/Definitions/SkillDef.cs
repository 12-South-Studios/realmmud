using Realm.Library.Common.Data;
using Realm.Library.Common.Extensions;
using Realm.Library.Common.Objects;

namespace Realm.Data.Definitions
{
    /// <summary>
    /// Definition of an Archetype
    /// </summary>
    public class SkillDef : Definition
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public SkillDef(long id, string name, DictionaryAtom definition)
            : base(id, name, definition)
        {
        }

        public string DisplayName => Def.GetString("DisplayName");

        public string DisplayDescription => Def.GetString("DisplayDescription");

        public SkillCategoryDef SkillCategory => (SkillCategoryDef)
            StaticDataManager.GetStaticData(Globals.SystemTypes.SkillCategory,
                Def.GetString("SkillCategoryID"));

        public Globals.Statistics Statistic => EnumerationExtensions.GetEnum<Globals.Statistics>(Def.GetInt("StatisticID"));

        public int MaxValue => Def.GetInt("MaxValue");

        public bool IsMasterable => Def.GetBool("IsMasterable");

        public SkillDef ParentSkill
        {
            get
            {
                var def = StaticDataManager.GetStaticData(Globals.SystemTypes.Skill,
                                                                   Def.GetString("ParentSkillID"));
                return def.IsNull() ? null : (SkillDef)def;
            }
        }
    }
}