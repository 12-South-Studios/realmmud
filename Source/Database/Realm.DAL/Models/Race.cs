using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using Realm.DAL.Enumerations;

namespace Realm.DAL.Models
{
    [Table("Races")]
    public class Race : Primitive
    {
        [Required]
        public string DisplayDescription { get; set; }

        public int Bits { get; set; }

        public SizeTypes SizeType { get; set; }

        public int BaseHealth { get; set; }

        public int BaseMana { get; set; }

        public int BaseStamina { get; set; }

        [MaxLength(5)]
        public string Abbreviation { get; set; }

        public int? TagSetId { get; set; }
        public virtual TagSet TagSet { get; set; }

        public virtual ICollection<RaceAbility> Abilities { get; set; }

        public virtual ICollection<RaceHitLocation> HitLocations { get; set; }

        public virtual ICollection<RaceStatistic> Statistics { get; set; }

        public static void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Race>()
                .HasOptional(x => x.TagSet)
                .WithMany()
                .WillCascadeOnDelete(true);

            modelBuilder.Entity<Race>()
                .HasOptional(x => x.Abilities)
                .WithMany()
                .WillCascadeOnDelete(true);

            modelBuilder.Entity<Race>()
                .HasOptional(x => x.HitLocations)
                .WithMany()
                .WillCascadeOnDelete(true);

            modelBuilder.Entity<Race>()
                .HasOptional(x => x.Statistics)
                .WithMany()
                .WillCascadeOnDelete(true);
        }
    }
}