using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;

namespace Realm.DAL.Models
{
    [Table("Archetypes")]
    public class Archetype : Primitive
    {
        [Required]
        public virtual SystemString DisplayDescription { get; set; }

        public virtual TagSet TagSet { get; set; }

        public virtual ICollection<ArchetypeAbility> Abilities { get; set; }

        public virtual ICollection<ArchetypeSkillCategory> SkillCategories { get; set; }

        public virtual ICollection<ArchetypeStatistic> Statistics { get; set; }

        public static void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Archetype>()
                .HasRequired(x => x.DisplayName)
                .WithMany()
                .WillCascadeOnDelete(true);

            modelBuilder.Entity<Archetype>()
                .HasRequired(x => x.DisplayDescription)
                .WithMany()
                .WillCascadeOnDelete(true);

            modelBuilder.Entity<Archetype>()
                .HasOptional(x => x.TagSet)
                .WithMany()
                .WillCascadeOnDelete(true);

            modelBuilder.Entity<Archetype>()
                .HasOptional(x => x.Abilities)
                .WithMany()
                .WillCascadeOnDelete(true);

            modelBuilder.Entity<Archetype>()
                .HasOptional(x => x.SkillCategories)
                .WithMany()
                .WillCascadeOnDelete(true);

            modelBuilder.Entity<Archetype>()
                .HasOptional(x => x.Statistics)
                .WithMany()
                .WillCascadeOnDelete(true);
        }
    }
}