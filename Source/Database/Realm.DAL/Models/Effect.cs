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
        public string DisplayDescription { get; set; }

        [Required]
        public EffectTypes EffectType { get; set; }

        public int Duration { get; set; }

        public int Bits { get; set; }

        public Statistic ResistStatistic { get; set; }

        public int? OnFailEffectId { get; set; }
        public virtual Effect OnFailEffect { get; set; }

        public int? OnResistEffectId { get; set; }
        public virtual Effect OnResistEffect { get; set; }

        public int? TagSetId { get; set; }
        public virtual TagSet TagSet { get; set; }

        public int MovementModeBitField { get; set; }

        public string ApplicationTextSelf { get; set; }

        public string ApplicationTextOther { get; set; }

        public string FadeTextSelf { get; set; }

        public string FadeTextOther { get; set; }

        public virtual ICollection<EffectDynamicZone> DynamicZones { get; set; }

        public virtual ICollection<EffectHealthChange> HealthChanges { get; set; }

        public virtual ICollection<EffectPosition> Positions { get; set; }

        public virtual ICollection<EffectPrimitive> Primitives { get; set; }

        public virtual ICollection<EffectStatMod> StatMods { get; set; }

        public static void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Effect>()
                .HasOptional(x => x.OnResistEffect)
                .WithMany()
                .HasForeignKey(x => x.OnResistEffectId);

            modelBuilder.Entity<Effect>()
                .HasOptional(x => x.OnFailEffect)
                .WithMany()
                .HasForeignKey(x => x.OnFailEffectId);
        }
    }
}