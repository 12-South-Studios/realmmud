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

        [ForeignKey("RaceId")]
        public virtual Race Race { get; set; }

        public int? NotRaceId { get; set; }

        [ForeignKey("NotRaceId")]
        public virtual Race NotRace { get; set; }

        public Statistic Statistic { get; set; }

        public virtual Skill Skill { get; set; }

        public int Value { get; set; }

        public int Level { get; set; }

        public int? QuestCompletedId { get; set; }

        [ForeignKey("QuestCompletedId")]
        public virtual Quest QuestCompleted { get; set; }

        public int? QuestNotCompletedId { get; set; }

        [ForeignKey("QuestNotCompletedId")]
        public virtual Quest QuestNotCompleted { get; set; }

        public virtual Item HasItem { get; set; }

        public virtual Faction Faction { get; set; }

        public int FactionLevel { get; set; }

        [Required]
        public int QuestId { get; set; }

        [ForeignKey("QuestId")]
        public Quest Quest { get; set; }
    }
}