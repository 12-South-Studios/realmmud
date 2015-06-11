using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Realm.DAL.Enumerations;

namespace Realm.DAL.Models
{
    [Table("Mobiles")]
    public class Mobile : IPrimitive
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

        public SizeTypes SizeType { get; set; }

        public MobileTypes MobileType { get; set; }

        public int Bits { get; set; }

        public int? RaceId { get; set; }
        public virtual Race Race { get; set; }

        public int? ConversationId { get; set; }
        public virtual Conversation Conversation { get; set; }

        public int AccessLevel { get; set; }

        public GenderTypes GenderType { get; set; }

        public int Level { get; set; }

        public int? FactionId { get; set; }
        public virtual Faction Faction { get; set; }

        public int? TagSetId { get; set; }
        public virtual TagSet TagSet { get; set; }

        public virtual ICollection<MobileAbility> Abilities { get; set; }

        public virtual ICollection<MobileAI> AIs { get; set; }

        public virtual ICollection<MobileEquipment> Equipment { get; set; }

        public virtual ICollection<MobileMudProg> MudProgs { get; set; }

        public virtual ICollection<MobileResource> Resources { get; set; }

        public virtual ICollection<MobileStatistic> Statistics { get; set; }

        public virtual ICollection<MobileTreasure> Treasures { get; set; }

        public virtual ICollection<MobileTreasureTable> TreasureTables { get; set; }

        public virtual ICollection<MobileVendor> Vendors { get; set; }
    }
}