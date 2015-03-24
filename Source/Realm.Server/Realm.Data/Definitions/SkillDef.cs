using Realm.Library.Common;
using Realm.Library.Common.Data;

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

        public string DisplayName { get { return Def.GetString("DisplayName"); } }

        public string DisplayDescription { get { return Def.GetString("DisplayDescription"); } }

        public SkillCategoryDef SkillCategory
        {
            get
            {
                return
                    (SkillCategoryDef)
                    StaticDataManager.GetStaticData(Globals.Globals.SystemTypes.SkillCategory,
                                                             Def.GetString("SkillCategoryID"));
            }
        }

        public Globals.Globals.Statistics Statistic
        {
            get { return EnumerationExtensions.GetEnum<Globals.Globals.Statistics>(Def.GetInt("StatisticID")); }
        }

        public int MaxValue { get { return Def.GetInt("MaxValue"); } }

        public bool IsMasterable { get { return Def.GetBool("IsMasterable"); } }

        public SkillDef ParentSkill
        {
            get
            {
                var def = StaticDataManager.GetStaticData(Globals.Globals.SystemTypes.Skill,
                                                                   Def.GetString("ParentSkillID"));
                return def.IsNull() ? null : (SkillDef)def;
            }
        }
    }
}