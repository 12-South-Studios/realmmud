using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using Realm.DAL.Enumerations;

namespace Realm.DAL.Models
{
    [Table("Abilities")]
    public class Ability : Primitive
    {
        [Required]
        public virtual SystemString DisplayDescription { get; set; }

        public int ManaCost { get; set; }

        public int StaminaCost { get; set; }

        public float PreDelay { get; set; }

        public float PostDelay { get; set; }

        public Statistic OffensiveStat { get; set; }

        public Statistic DefensiveStat { get; set; }

        public int Bits { get; set; }

        public virtual Terrain Terrain { get; set; }

        public virtual TagSet TagSet { get; set; }

        public virtual Skill InterruptionResistSkill { get; set; }

        public virtual Effect InterruptionEffect { get; set; }

        public float RechargeRate { get; set; }

        public TargetClassTypes TargetClass { get; set; }

        public virtual SystemString VerbalText { get; set; }

        public virtual SystemString BeginUseText { get; set; }

        public virtual SystemString UseText { get; set; }

        public virtual ICollection<AbilityEffect> Effects { get; set; }

        public virtual ICollection<GuildAbilityUpgrade> GuildUpgrades { get; set; }

        public virtual ICollection<AbilityPrerequisite> Prerequisites { get; set; }

        public virtual ICollection<AbilityReagant> Reagants { get; set; }

        public static void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Ability>()
                .HasRequired(x => x.DisplayName)
                .WithMany()
                .WillCascadeOnDelete(true);

            modelBuilder.Entity<Ability>()
                .HasRequired(x => x.DisplayDescription)
                .WithMany()
                .WillCascadeOnDelete(true);

            modelBuilder.Entity<Ability>()
                .HasOptional(x => x.VerbalText)
                .WithMany()
                .WillCascadeOnDelete(true);

            modelBuilder.Entity<Ability>()
                .HasOptional(x => x.BeginUseText)
                .WithMany()
                .WillCascadeOnDelete(true);

            modelBuilder.Entity<Ability>()
                .HasOptional(x => x.UseText)
                .WithMany()
                .WillCascadeOnDelete(true);

            modelBuilder.Entity<Ability>()
                .HasOptional(x => x.TagSet)
                .WithMany()
                .WillCascadeOnDelete(true);

            modelBuilder.Entity<Ability>()
                .HasOptional(x => x.Effects)
                .WithMany()
                .WillCascadeOnDelete(true);

            modelBuilder.Entity<Ability>()
                .HasOptional(x => x.GuildUpgrades)
                .WithMany()
                .WillCascadeOnDelete(true);

            modelBuilder.Entity<Ability>()
                .HasOptional(x => x.Prerequisites)
                .WithMany()
                .WillCascadeOnDelete(true);

            modelBuilder.Entity<Ability>()
                .HasOptional(x => x.Reagants)
                .WithMany()
                .WillCascadeOnDelete(true);
        }
    }
}