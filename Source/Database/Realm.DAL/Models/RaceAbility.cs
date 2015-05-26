using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Realm.DAL.Common;

namespace Realm.DAL.Models
{
    [Table("RaceAbilities")]
    public class RaceAbility : Entity
    {
        public int? AbilityId { get; set; }
        public virtual Ability Ability { get; set; }

        [Required]
        public int RaceId { get; set; }
        public virtual Race Race { get; set; }
    }
}