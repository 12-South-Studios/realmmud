using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Realm.DAL.Enumerations;

namespace Realm.DAL.Models
{
    [Table("Abilities")]
    public class Ability : IPrimitive
    {
        [Key]
        public int Id { get; set; }

        public DateTime? CreateDateUtc { get; set; }

        [Required]
        [MaxLength(255)]
        public string SystemName { get; set; }

        [Required]
        public int? SystemClassId { get; set; }
        public virtual SystemClass SystemClass { get; set; }

        [Required]
        [MaxLength(255)]
        public string DisplayName { get; set; }

        [Required]
        [MaxLength(2048)]
        public string DisplayDescription { get; set; }

        public int ManaCost { get; set; }

        public int StaminaCost { get; set; }

        public float PreDelay { get; set; }

        public float PostDelay { get; set; }

        public Statistic OffensiveStat { get; set; }

        public Statistic DefensiveStat { get; set; }

        public int Bits { get; set; }

        public int? TerrainId { get; set; }
        public virtual Terrain Terrain { get; set; }

        public int? TagSetId { get; set; }
        public virtual TagSet TagSet { get; set; }

        public int? InterruptionResistSkillId { get; set; }
        public virtual Skill InterruptionResistSkill { get; set; }

        public int? InterruptionEffectId { get; set; }
        public virtual Effect InterruptionEffect { get; set; }

        public float RechargeRate { get; set; }

        public TargetClassTypes TargetClass { get; set; }

        public string VerbalText { get; set; }

        public string BeginUseText { get; set; }

        public string UseText { get; set; }

        public virtual ICollection<AbilityEffect> Effects { get; set; }

        public virtual ICollection<GuildAbilityUpgrade> GuildUpgrades { get; set; }

        public virtual ICollection<AbilityPrerequisite> Prerequisites { get; set; }

        public virtual ICollection<AbilityReagant> Reagants { get; set; }
    }
}