using System.ComponentModel.DataAnnotations.Schema;
using Realm.DAL.Common;
using Realm.DAL.Enumerations;

namespace Realm.DAL.Models
{
    [Table("ItemPrerequisites")]
    public class ItemPrerequisite : Entity
    {
        public int MinLevel { get; set; }

        public virtual Race Race { get; set; }

        public virtual Faction Faction { get; set; }

        public int FactionLevel { get; set; }

        public Statistic Statistic { get; set; }

        public int StatisticValue { get; set; }

        public virtual Skill Skill { get; set; }

        public int SkillValue { get; set; }

        public GenderTypes Gender { get; set; }

        public Archetype Archetype { get; set; }
    }
}