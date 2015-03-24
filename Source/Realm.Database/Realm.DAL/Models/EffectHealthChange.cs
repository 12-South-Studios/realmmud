using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Realm.DAL.Common;
using Realm.DAL.Enumerations;

namespace Realm.DAL.Models
{
    [Table("EffectHealthChanges")]
    public class EffectHealthChange : Entity
    {
        public HealthChangeTypes HealthChangeType { get; set; }

        public int ChangeMin { get; set; }

        public int ChangeMax { get; set; }

        public DamageTypes DamageType { get; set; }

        [Required]
        public int EffectId { get; set; }

        [ForeignKey("EffectId")]
        public Effect Effect { get; set; }
    }
}