using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Realm.DAL.Models
{
    [Table("Zones")]
    public class Zone : Primitive
    {
        [Required]
        public string DisplayDescription { get; set; }

        public int Bits { get; set; }

        public int RecycleTime { get; set; }

        public int? TagSetId { get; set; }
        public virtual TagSet TagSet { get; set; }

        public int MaxDynamicZones { get; set; }

        public int MinDyanmicZoneFrequencySeconds { get; set; }

        public virtual ICollection<ZoneAccess> Accesses { get; set; }

        public virtual ICollection<ZoneDynamic> Dynamics { get; set; }

        public virtual ICollection<ZoneReset> Resets { get; set; }

        public virtual ICollection<ZoneSpace> Spaces { get; set; }

        public virtual ICollection<ZoneSpawn> Spawns { get; set; }
    }
}