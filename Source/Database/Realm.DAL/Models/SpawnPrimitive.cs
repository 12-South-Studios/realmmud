using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Realm.DAL.Common;

namespace Realm.DAL.Models
{
    [Table("SpawnPrimitives")]
    public class SpawnPrimitive : Entity
    {
        public virtual Primitive Primitive { get; set; }

        [Required]
        public int SpawnId { get; set; }

        [ForeignKey("SpawnId")]
        public Spawn Spawn { get; set; }
    }
}