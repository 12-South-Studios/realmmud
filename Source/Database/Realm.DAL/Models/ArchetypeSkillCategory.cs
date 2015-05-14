using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Realm.DAL.Common;

namespace Realm.DAL.Models
{
    [Table("ArchetypeSkillCategories")]
    public class ArchetypeSkillCategory : Entity
    {
        public virtual SkillCategory SkillCategory { get; set; }

        public bool IsPreferred { get; set; }

        public bool IsRestricted { get; set; }

        [Required]
        public int ArchetypeId { get; set; }

        [ForeignKey("ArchetypeId")]
        public Archetype Archetype { get; set; }
    }
}