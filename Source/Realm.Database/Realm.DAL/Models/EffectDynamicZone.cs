using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Realm.DAL.Common;

namespace Realm.DAL.Models
{
    [Table("EffectDynamicZones")]
    public class EffectDynamicZone : Entity
    {
        public virtual Zone Zone { get; set; }

        [Required]
        public int EffectId { get; set; }

        [ForeignKey("EffectId")]
        public Effect Effect { get; set; }
    }
}