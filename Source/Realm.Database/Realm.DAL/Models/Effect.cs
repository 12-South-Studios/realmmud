using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using Realm.DAL.Enumerations;

namespace Realm.DAL.Models
{
    [Table("Effects")]
    public class Effect : Primitive
    {
        [Required]
        public virtual SystemString DisplayDescription { get; set; }

        [Required]
        public EffectTypes EffectType { get; set; }

        public int Duration { get; set; }

        public int Bits { get; set; }

        public Statistic ResistStatistic { get; set; }

        public int? OnFailEffectId { get; set; }

        [ForeignKey("OnFailEffectId")]
        public virtual Effect OnFailEffect { get; set; }

        public int? OnResistEffectId { get; set; }

        [ForeignKey("OnResistEffectId")]
        public virtual Effect OnResistEffect { get; set; }

        public virtual TagSet TagSet { get; set; }

        public int MovementModeBitField { get; set; }

        public virtual SystemString ApplicationTextSelf { get; set; }

        public virtual SystemString ApplicationTextOther { get; set; }

        public virtual SystemString FadeTextSelf { get; set; }

        public virtual SystemString FadeTextOther { get; set; }

        public virtual ICollection<EffectDynamicZone> DynamicZones { get; set; }

        public virtual ICollection<EffectHealthChange> HealthChanges { get; set; }

        public virtual ICollection<EffectPosition> Positions { get; set; }

        public virtual ICollection<EffectPrimitive> Primitives { get; set; }

        public virtual ICollection<EffectStatMod> StatMods { get; set; }

        public static void OnModelCreating(DbModelBuilder modelBuilder)
        {
           modelBuilder.Entity<Effect>()
               .HasRequired(x => x.DisplayName)
               .WithMany()
               .WillCascadeOnDelete(true);

            modelBuilder.Entity<Effect>()
                .HasRequired(x => x.DisplayDescription)
                .WithMany()
                .WillCascadeOnDelete(true);

            modelBuilder.Entity<Effect>()
                .HasOptional(x => x.TagSet)
                .WithMany()
                .WillCascadeOnDelete(true);

            modelBuilder.Entity<Effect>()
                .HasOptional(x => x.ApplicationTextSelf)
                .WithMany()
                .WillCascadeOnDelete(true);

            modelBuilder.Entity<Effect>()
                .HasOptional(x => x.ApplicationTextOther)
                .WithMany()
                .WillCascadeOnDelete(true);

            modelBuilder.Entity<Effect>()
                 .HasOptional(x => x.FadeTextSelf)
                 .WithMany()
                 .WillCascadeOnDelete(true);

            modelBuilder.Entity<Effect>()
                .HasOptional(x => x.FadeTextOther)
                .WithMany()
                .WillCascadeOnDelete(true);

            modelBuilder.Entity<Effect>()
                .HasOptional(x => x.DynamicZones)
                .WithMany()
                .WillCascadeOnDelete(true);

            modelBuilder.Entity<Effect>()
                .HasOptional(x => x.HealthChanges)
                .WithMany()
                .WillCascadeOnDelete(true);

            modelBuilder.Entity<Effect>()
                .HasOptional(x => x.Positions)
                .WithMany()
                .WillCascadeOnDelete(true);

            modelBuilder.Entity<Effect>()
                .HasOptional(x => x.Primitives)
                .WithMany()
                .WillCascadeOnDelete(true);

            modelBuilder.Entity<Effect>()
                .HasOptional(x => x.StatMods)
                .WithMany()
                .WillCascadeOnDelete(true);
        }
    }
}