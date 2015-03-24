using System.ComponentModel.DataAnnotations.Schema;
using Realm.DAL.Common;
using Realm.DAL.Enumerations;

namespace Realm.DAL.Models
{
    [Table("ItemTraps")]
    public class ItemTrap : Entity
    {
        public Statistic DisarmStatistic { get; set; }

        public Skill DisarmSkill { get; set; }

        public DifficultyTypes Difficulty { get; set; }

        public TargetClassTypes OnFailTargetClassType { get; set; }

        public Effect OnFailEffect { get; set; }

        public int NotifyRadius { get; set; }
    }
}