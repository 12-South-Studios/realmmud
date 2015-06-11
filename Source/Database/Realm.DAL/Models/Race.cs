using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Realm.DAL.Enumerations;

namespace Realm.DAL.Models
{
    [Table("Races")]
    public class Race : IPrimitive
    {
        [Key]
        public int Id { get; set; }

        public DateTime? CreateDateUtc { get; set; }

        [Required]
        [MaxLength(255), MinLength(5)]
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
    }
}