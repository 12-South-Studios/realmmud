using System.ComponentModel.DataAnnotations.Schema;
using Realm.DAL.Common;
using Realm.DAL.Enumerations;

namespace Realm.DAL.Models
{
    [Table("ItemTraps")]
    public class ItemTrap : Entity
    {
        public int ItemId { get; set; }
        public virtual Item Item { get; set; }

        public Statistic DisarmStatistic { get; set; }

        public int? DisarmSkillId { get; set; }
        public virtual Skill DisarmSkill { get; set; }

        public DifficultyTypes Difficulty { get; set; }

        public TargetClassTypes OnFailTargetClassType { get; set; }

        public int? OnFailEffectId { get; set; }
        public virtual Effect OnFailEffect { get; set; }

        public int NotifyRadius { get; set; }
    }
}