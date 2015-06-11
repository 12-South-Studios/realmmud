using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Realm.DAL.Common;

namespace Realm.DAL.Models
{
    [Table("EffectPrimitives")]
    public class EffectPrimitive : Entity
    {
        public int? PrimitiveId { get; set; }
        public virtual IPrimitive Primitive { get; set; }

        [Required]
        public int EffectId { get; set; }
        public virtual Effect Effect { get; set; }
    }
}