using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;

namespace Realm.DAL.Models
{
    [Table("Zones")]
    public class Zone : Primitive
    {
        [Required]
        public virtual SystemString DisplayDescription { get; set; }

        public int Bits { get; set; }

        public int RecycleTime { get; set; }

        public virtual TagSet TagSet { get; set; }

        public int MaxDynamicZones { get; set; }

        public int MinDyanmicZoneFrequencySeconds { get; set; }

        public virtual ICollection<ZoneAccess> Accesses { get; set; }

        public virtual ICollection<ZoneDynamic> Dynamics { get; set; }

        public virtual ICollection<ZoneReset> Resets { get; set; }

        public virtual ICollection<ZoneSpace> Spaces { get; set; }

        public virtual ICollection<ZoneSpawn> Spawns { get; set; }

        public static void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Zone>()
                .HasRequired(x => x.DisplayName)
                .WithMany()
                .WillCascadeOnDelete(true);

            modelBuilder.Entity<Zone>()
                .HasRequired(x => x.DisplayDescription)
                .WithMany()
                .WillCascadeOnDelete(true);

            modelBuilder.Entity<Zone>()
                .HasOptional(x => x.TagSet)
                .WithMany()
                .WillCascadeOnDelete(true);

            modelBuilder.Entity<Zone>()
                .HasOptional(x => x.Accesses)
                .WithMany()
                .WillCascadeOnDelete(true);

            modelBuilder.Entity<Zone>()
                .HasOptional(x => x.Dynamics)
                .WithMany()
                .WillCascadeOnDelete(true);

            modelBuilder.Entity<Zone>()
                .HasOptional(x => x.Resets)
                .WithMany()
                .WillCascadeOnDelete(true);

            modelBuilder.Entity<Zone>()
                .HasOptional(x => x.Spaces)
                .WithMany()
                .WillCascadeOnDelete(true);

            modelBuilder.Entity<Zone>()
                .HasOptional(x => x.Spawns)
                .WithMany()
                .WillCascadeOnDelete(true);

            ZoneAccess.OnModelCreating(modelBuilder);
        }
    }
}