using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Realm.DAL.Common;

namespace Realm.DAL.Models
{
    [Table("EffectPrimitives")]
    public class EffectPrimitive : Entity
    {
        public virtual Primitive Primitive { get; set; }

        [Required]
        public int EffectId { get; set; }

        [ForeignKey("EffectId")]
        public Effect Effect { get; set; }
    }
}