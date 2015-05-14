using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
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

        public virtual TagSet TagSet { get; set; }

        public virtual ICollection<SpawnLocation> Locations { get; set; }

        public virtual ICollection<SpawnPrimitive> Primitives { get; set; }

        public static void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Spawn>()
                .HasRequired(x => x.DisplayName)
                .WithMany()
                .WillCascadeOnDelete(true);

            modelBuilder.Entity<Spawn>()
                .HasOptional(x => x.TagSet)
                .WithMany()
                .WillCascadeOnDelete(true);

            modelBuilder.Entity<Spawn>()
                .HasOptional(x => x.Locations)
                .WithMany()
                .WillCascadeOnDelete(true);

            modelBuilder.Entity<Spawn>()
                .HasOptional(x => x.Primitives)
                .WithMany()
                .WillCascadeOnDelete(true);
        }
    }
}