using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Realm.DAL.Common;
using Realm.DAL.Enumerations;

namespace Realm.Live.DAL.Models
{
    [Table("Characters")]
    public class Character : Entity
    {
        public int? UserId { get; set; }
        public virtual User User { get; set; }

        [MaxLength(50)]
        public string Name { get; set; }

        public DateTime? DeletedOn { get; set; }

        public int? GuildId { get; set; }
        public virtual Guild Guild { get; set; }

        public int? LocationId { get; set; }

        public int? RaceId { get; set; }

        public int Level { get; set; }

        public int Experience { get; set; }

        public int Coin { get; set; }

        public GenderTypes Gender { get; set; }

        public int? AutoAttackAbilityId { get; set; }

        public int TrainingPoints { get; set; }

        public int? BankId { get; set; }
        public virtual Bank Bank { get; set; }

        public virtual ICollection<CharacterAbility> Abilities { get; set; }

        public virtual ICollection<CharacterAuction> Auctions { get; set; }

        public virtual ICollection<CharacterChannel> Channels { get; set; }

        public virtual ICollection<CharacterFaction> Factions { get; set; }

        public virtual ICollection<CharacterItem> Items { get; set; }

        public virtual ICollection<CharacterMail> Mail { get; set; }

        public virtual ICollection<CharacterStatistic> Statistics { get; set; }

        public virtual ICollection<CharacterProperty> Properties { get; set; } 
    }
}
