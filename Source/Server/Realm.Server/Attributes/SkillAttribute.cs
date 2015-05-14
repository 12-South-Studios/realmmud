using Realm.Library.Common;
using Realm.Data.Definitions;

namespace Realm.Server.Attributes
{
    /// <summary>
    /// Attribute used for tracking Skills
    /// </summary>
    public class SkillAttribute : GameAttribute
    {
        private SkillDef SkillDef { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="skill"></param>
        public SkillAttribute(SkillDef skill) : base(skill.ID, skill.Name)
        {
            SkillDef = skill;
        }

        /// <summary>
        /// 
        /// </summary>
        public int TotalXp { get; private set; }

        /// <summary>
        /// Calculates the total rating of the skill plus the rating of each 
        /// of the Skill's parent skills, all the way back to the root.
        /// </summary>
        public int GrossRating
        {
            get
            {
                var totalRating = Rating;
                var parent = SkillDef.ParentSkill;
                while (parent.IsNotNull())
                {
                    var skill = Owner.GetContext("AttributeContext").CastAs<AttributeContext>().Get(parent.ID);
                    if (skill.IsNotNull())
                        totalRating += skill.Rating;
                }
                return totalRating;
            }
        }
    }
}
