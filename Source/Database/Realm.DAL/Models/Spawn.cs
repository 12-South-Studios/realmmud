using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Realm.DAL.Enumerations;

namespace Realm.DAL.Models
{
    [Table("Spawns")]
    public class Spawn : Primitive
    {
        public int MinQuantity { get; set; }

        public int MaxQuantity { get; set; }

        public int Chance { get; set; }

        public int RespawnPeriod { get; set; }

        public SpawnTypes SpawnType { get; set; }

        public int? TagSetId { get; set; }
        public virtual TagSet TagSet { get; set; }

        public virtual ICollection<SpawnLocation> Locations { get; set; }

        public virtual ICollection<SpawnPrimitive> Primitives { get; set; }
    }
}