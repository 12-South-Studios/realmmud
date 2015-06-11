using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Realm.DAL.Common;

namespace Realm.DAL.Models
{
    [Table("TreasurePrimitives")]
    public class TreasurePrimitive : IEntity
    {
        [Key]
        public int Id { get; set; }

        public DateTime? CreateDateUtc { get; set; }

        [Required]
        public int PrimitiveId { get; set; }
        public virtual IPrimitive Primitive { get; set; }

        public int Weight { get; set; }

        public int MaxPulls { get; set; }

        [Required]
        public int TreasureId { get; set; }
        public virtual Treasure Treasure { get; set; }

        public TreasurePrimitive()
        {
            MaxPulls = -1;
        }


    }
}