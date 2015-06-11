using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Realm.DAL.Common;

namespace Realm.DAL.Models
{
    [Table("TerrainRestrictions")]
    public class TerrainRestriction : IEntity
    {
        [Required]
        public MovementMode MoementMode { get; set; }

        [Required]
        public int TerrainId { get; set; }
        public virtual Terrain Terrain { get; set; }

        [Key]
        public int Id { get; set; }

        public DateTime? CreateDateUtc { get; set; }
    }
}