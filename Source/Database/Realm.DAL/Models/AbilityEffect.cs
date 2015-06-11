using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Realm.DAL.Common;
using Realm.DAL.Enumerations;

namespace Realm.DAL.Models
{
    [Table("AbilityEffects")]
    public class AbilityEffect : IEntity
    {
        [Required]
        public int EffectId { get; set; }
        public virtual Effect Effect { get; set; }

        public TargetClassTypes TargetClass { get; set; }

        public int MaxNumber { get; set; }

        [Required]
        public int AbilityId { get; set; }
        public virtual Ability Ability { get; set; }

        [Key]
        public int Id { get; set; }

        public DateTime? CreateDateUtc { get; set; }
    }
}