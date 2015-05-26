using System.ComponentModel.DataAnnotations.Schema;
using Realm.DAL.Common;
using Realm.DAL.Enumerations;

namespace Realm.DAL.Models
{
    [Table("ItemPrerequisites")]
    public class ItemPrerequisite : Entity
    {
        public int ItemId { get; set; }
        public virtual Item Item { get; set; }

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

        public GenderTypes Gender { get; set; }

        public int? ArchetypeId { get; set; }
        public virtual Archetype Archetype { get; set; }
    }
}