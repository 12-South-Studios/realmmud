using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Realm.DAL.Common;

namespace Realm.DAL.Models
{
    [Table("EffectDynamicZones")]
    public class EffectDynamicZone : Entity
    {
        public int? ZoneId { get; set; }
        public virtual Zone Zone { get; set; }

        [Required]
        public int EffectId { get; set; }
        public virtual Effect Effect { get; set; }
    }
}