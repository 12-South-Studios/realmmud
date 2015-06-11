using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Realm.DAL.Enumerations;
using Realm.DAL.Common;

namespace Realm.DAL.Models
{
    [Table("SpacePortals")]
    public class SpacePortal : IEntity
    {
        [Required]
        public DirectionTypes Direction { get; set; }

        [Required]
        public int TargetSpaceId { get; set; }
        public virtual Space TargetSpace { get; set; }

        public int? BarrierId { get; set; }
        public virtual Barrier Barrier { get; set; }

        public int Bits { get; set; }

        [Required]
        [MaxLength(255), MinLength(2)]
        public string Keywords { get; set; }

        [Key]
        public int Id { get; set; }

        public DateTime? CreateDateUtc { get; set; }
    }
}