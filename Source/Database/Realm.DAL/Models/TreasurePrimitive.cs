using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Realm.DAL.Common;

namespace Realm.DAL.Models
{
    [Table("TreasurePrimitives")]
    public class TreasurePrimitive : Entity
    {
        public virtual Primitive Primitive { get; set; }

        public int Weight { get; set; }

        public int MaxPulls { get; set; }

        [Required]
        public int TreasureId { get; set; }

        [ForeignKey("TreasureId")]
        public Treasure Treasure { get; set; }

        public TreasurePrimitive()
        {
            MaxPulls = -1;
        }
    }
}