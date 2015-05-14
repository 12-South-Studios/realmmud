using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Realm.DAL.Common;

namespace Realm.DAL.Models
{
    [Table("MobileAbilities")]
    public class MobileAbility : Entity
    {
        public virtual Ability Ability { get; set; }

        public bool IsDefault { get; set; }

        [Required]
        public int MobileId { get; set; }

        [ForeignKey("MobileId")]
        public Mobile Mobile { get; set; }
    }
}