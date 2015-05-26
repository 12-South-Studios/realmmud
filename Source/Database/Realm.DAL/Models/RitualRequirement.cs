using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Realm.DAL.Enumerations;
using Realm.DAL.Common;

namespace Realm.DAL.Models
{
    [Table("RitualRequirements")]
    public class RitualRequirement : Entity
    {
        public int MinLevel { get; set; }

        public int? RaceId { get; set; }
        public virtual Race Race { get; set; }

        public int? FactionId { get; set; }
        public virtual Faction Faction { get; set; }

        public int FactionLevel { get; set; }

        public Statistic Statistic { get; set; }

        public int? SkillId { get; set; }
        public virtual Skill Skill { get; set; }

        public int MinValue { get; set; }

        [Required]
        public int RitualId { get; set; }
        public virtual Ritual Ritual { get; set; }
    }
}