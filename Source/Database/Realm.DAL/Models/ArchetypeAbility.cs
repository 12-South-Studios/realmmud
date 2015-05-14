using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Realm.DAL.Common;

namespace Realm.DAL.Models
{
    [Table("ArchetypeAbilities")]
    public class ArchetypeAbility : Entity
    {
        public virtual Ability Ability { get; set; }

        public bool IsExempt { get; set; }

        public bool IsAutoAttack { get; set; }

        [Required]
        public int ArchetypeId { get; set; }

        [ForeignKey("ArchetypeId")]
        public Archetype Archetype { get; set; }
    }
}