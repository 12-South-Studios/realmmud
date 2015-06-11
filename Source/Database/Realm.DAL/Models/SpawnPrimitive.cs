using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Realm.DAL.Common;

namespace Realm.DAL.Models
{
    [Table("SpawnPrimitives")]
    public class SpawnPrimitive : Entity
    {
        public int? PrimitiveId { get; set; }
        public virtual IPrimitive Primitive { get; set; }

        [Required]
        public int SpawnId { get; set; }
        public virtual Spawn Spawn { get; set; }
    }
}