using System.ComponentModel.DataAnnotations.Schema;
using Realm.DAL.Common;
using Realm.DAL.Enumerations;

namespace Realm.DAL.Models
{
    [Table("ItemLocks")]
    public class ItemLock : Entity
    {
        public int ItemId { get; set; }
        public virtual Item Item { get; set; }

        public Statistic PickStatistic { get; set; }

        public int? PickSkillId { get; set; }
        public virtual Skill PickSkill { get; set; }

        public DifficultyTypes Difficulty { get; set; }

        public int? KeyItemId { get; set; }
        public virtual Item KeyItem { get; set; }
    }
}