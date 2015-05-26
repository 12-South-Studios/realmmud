using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Realm.DAL.Common;

namespace Realm.DAL.Models
{
    [Table("ArchetypeAbilities")]
    public class ArchetypeAbility : Entity
    {
        public int? AbilityId { get; set; }
        public virtual Ability Ability { get; set; }

        public bool IsExempt { get; set; }

        public bool IsAutoAttack { get; set; }

        [Required]
        public int ArchetypeId { get; set; }
        public virtual Archetype Archetype { get; set; }
    }
}