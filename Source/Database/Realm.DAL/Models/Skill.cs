using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Realm.DAL.Enumerations;

namespace Realm.DAL.Models
{
    [Table("Skills")]
    public class Skill : Primitive
    {
        [Required]
        public string DisplayDescription { get; set; }

        public int? SkillCategoryId { get; set; }
        public virtual SkillCategory SkillCategory { get; set; }

        public Statistic Statistic { get; set; }

        public int MaxValue { get; set; }

        public bool IsMasterable { get; set; }

        public int? ParentSkillId { get; set; }
        public virtual Skill ParentSkill { get; set; }
    }
}