using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Realm.DAL.Common;
using Realm.DAL.Enumerations;

namespace Realm.DAL.Models
{
    [Table("AbilityPrerequisites")]
    public class AbilityPrerequisite : Entity
    {
        public int MinLevel { get; set; }

        public int? RaceId { get; set; }
        public virtual Race Race { get; set; }

        public int? FactionId { get; set; }
        public virtual Faction Faction { get; set; }

        public int FactionLevel { get; set; }

        public Statistic Statistic { get; set; }

        public int StatisticValue { get; set; }

        public int? SkillId { get; set; }
        public virtual Skill Skill { get; set; }

        public int SkillValue { get; set; }

        [Required]
        public int AbilityId { get; set; }
        public virtual Ability Ability { get; set; }
    }
}