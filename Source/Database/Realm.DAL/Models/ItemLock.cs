using System.ComponentModel.DataAnnotations.Schema;
using Realm.DAL.Common;
using Realm.DAL.Enumerations;

namespace Realm.DAL.Models
{
    [Table("ItemLocks")]
    public class ItemLock : Entity
    {
        public Statistic PickStatistic { get; set; }

        public Skill PickSkill { get; set; }

        public DifficultyTypes Difficulty { get; set; }

        public Item KeyItem { get; set; }
    }
}