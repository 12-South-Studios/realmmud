using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Realm.DAL.Models
{
    [Table("Zones")]
    public class Zone : IPrimitive
    {
        [Key]
        public int Id { get; set; }

        public DateTime? CreateDateUtc { get; set; }

        [Required]
        [MaxLength(255), MinLength(4)]
        public string SystemName { get; set; }

        [Required]
        public int? SystemClassId { get; set; }
        public virtual SystemClass SystemClass { get; set; }

        [Required]
        [MaxLength(255), MinLength(5)]
        public string DisplayName { get; set; }

        [Required]
        [MaxLength(2048)]
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