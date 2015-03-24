using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Realm.DAL.Common;
using Realm.DAL.Enumerations;

namespace Realm.DAL.Models
{
    [Table("AbilityEffects")]
    public class AbilityEffect : Entity
    {
        public virtual Effect Effect { get; set; }

        public TargetClassTypes TargetClass { get; set; }

        public int MaxNumber { get; set; }

        [Required]
        public int AbilityId { get; set; }

        [ForeignKey("AbilityId")]
        public virtual Ability Ability { get; set; }
    }
}