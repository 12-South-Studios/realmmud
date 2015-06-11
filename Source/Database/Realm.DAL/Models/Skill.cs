using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Realm.DAL.Enumerations;

namespace Realm.DAL.Models
{
    [Table("Skills")]
    public class Skill : IPrimitive
    {
        [Key]
        public int Id { get; set; }

        public DateTime? CreateDateUtc { get; set; }

        [Required]
        [MaxLength(255), MinLength(5)]
        public string SystemName { get; set; }

        [Required]
        public int? SystemClassId { get; set; }
        public virtual SystemClass SystemClass { get; set; }

        [Required]
        [MaxLength(255), MinLength(5)]
        public string DisplayName { get; set; }

        [Required]
        [MaxLength(2048)]
        public string DisplayDescription { get; set; }

        [Required]
        public int SkillCategoryId { get; set; }
        public virtual SkillCategory SkillCategory { get; set; }

        [Required]
        public Statistic Statistic { get; set; }

        public int MaxValue { get; set; }

        public bool IsMasterable { get; set; }

        public int? ParentSkillId { get; set; }
        public virtual Skill ParentSkill { get; set; }
    }
}