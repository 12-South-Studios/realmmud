using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Realm.DAL.Enumerations;
using Realm.DAL.Common;

namespace Realm.DAL.Models
{
    [Table("QuestRequirements")]
    public class QuestRequirement : Entity
    {
        public int? RaceId { get; set; }
        public virtual Race Race { get; set; }

        public int? NotRaceId { get; set; }
        public virtual Race NotRace { get; set; }

        public Statistic Statistic { get; set; }

        public int? SkillId { get; set; }
        public virtual Skill Skill { get; set; }

        public int Value { get; set; }

        public int Level { get; set; }

        public int? QuestCompletedId { get; set; }
        public virtual Quest QuestCompleted { get; set; }

        public int? QuestNotCompletedId { get; set; }
        public virtual Quest QuestNotCompleted { get; set; }

        public int? HasItemId { get; set; }
        public virtual Item HasItem { get; set; }

        public int? FactionId { get; set; }
        public virtual Faction Faction { get; set; }

        public int FactionLevel { get; set; }

        [Required]
        public int QuestId { get; set; }
        public virtual Quest Quest { get; set; }
    }
}