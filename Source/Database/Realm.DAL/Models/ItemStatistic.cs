using System.ComponentModel.DataAnnotations.Schema;
using Realm.DAL.Common;
using Realm.DAL.Enumerations;

namespace Realm.DAL.Models
{
    [Table("ItemStatistics")]
    public class ItemStatistic : Entity
    {
        public int ItemId { get; set; }
        public virtual Item Item { get; set; }

        public Statistic Statistic { get; set; }

        public int? SkillId { get; set; }
        public virtual Skill Skill { get; set; }

        public int ValueMod { get; set; }
    }
}