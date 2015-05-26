using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Realm.DAL.Common;

namespace Realm.DAL.Models
{
    [Table("ZoneSpawns")]
    public class ZoneSpawn : Entity
    {
        public int? SpawnId { get; set; }
        public virtual Spawn Spawn { get; set; }

        [Required]
        public int ZoneId { get; set; }
        public virtual Zone Zone { get; set; }
    }
}