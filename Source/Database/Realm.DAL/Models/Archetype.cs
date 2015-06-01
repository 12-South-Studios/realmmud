using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Realm.DAL.Models
{
    [Table("Archetypes")]
    public class Archetype : Primitive
    {
        [Required]
        public string DisplayDescription { get; set; }

        public int? TagSetId { get; set; }
        public virtual TagSet TagSet { get; set; }

        public virtual ICollection<ArchetypeAbility> Abilities { get; set; }

        public virtual ICollection<ArchetypeSkillCategory> SkillCategories { get; set; }

        public virtual ICollection<ArchetypeStatistic> Statistics { get; set; }
    }
}