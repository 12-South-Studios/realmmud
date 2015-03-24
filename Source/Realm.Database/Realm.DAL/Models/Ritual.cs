using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;

namespace Realm.DAL.Models
{
    [Table("Rituals")]
    public class Ritual : Primitive
    {
        [Required]
        public virtual SystemString DisplayDescription { get; set; }

        public virtual Item MagicalNodeItem { get; set; }

        public int CastTime { get; set; }

        public virtual TagSet TagSet { get; set; }

        public virtual ICollection<RitualEffect> Effects { get; set; }
            
        public virtual ICollection<RitualParticipant> Participants { get; set; }

        public virtual ICollection<RitualReagant> Reagants { get; set; }

        public virtual ICollection<RitualRequirement> Requirements { get; set; }

        public static void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Ritual>()
                .HasRequired(x => x.DisplayName)
                .WithMany()
                .WillCascadeOnDelete(true);

            modelBuilder.Entity<Ritual>()
                .HasRequired(x => x.DisplayDescription)
                .WithMany()
                .WillCascadeOnDelete(true);

            modelBuilder.Entity<Ritual>()
                .HasOptional(x => x.TagSet)
                .WithMany()
                .WillCascadeOnDelete(true);

            modelBuilder.Entity<Ritual>()
                .HasOptional(x => x.Effects)
                .WithMany()
                .WillCascadeOnDelete(true);

            modelBuilder.Entity<Ritual>()
                .HasOptional(x => x.Participants)
                .WithMany()
                .WillCascadeOnDelete(true);

            modelBuilder.Entity<Ritual>()
                .HasOptional(x => x.Reagants)
                .WithMany()
                .WillCascadeOnDelete(true);

            modelBuilder.Entity<Ritual>()
                .HasOptional(x => x.Requirements)
                .WithMany()
                .WillCascadeOnDelete(true);
        }
    }
}