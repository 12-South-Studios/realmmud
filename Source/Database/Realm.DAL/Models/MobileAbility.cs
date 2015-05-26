using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Realm.DAL.Common;

namespace Realm.DAL.Models
{
    [Table("MobileAbilities")]
    public class MobileAbility : Entity
    {
        public int? AbilityId { get; set; }
        public virtual Ability Ability { get; set; }

        public bool IsDefault { get; set; }

        [Required]
        public int MobileId { get; set; }
        public virtual Mobile Mobile { get; set; }
    }
}