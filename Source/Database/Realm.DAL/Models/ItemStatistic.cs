using System.ComponentModel.DataAnnotations.Schema;
using Realm.DAL.Common;
using Realm.DAL.Enumerations;

namespace Realm.DAL.Models
{
    [Table("ItemStatistics")]
    public class ItemStatistic : Entity
    {
        public Statistic Statistic { get; set; }

        public Skill Skill { get; set; }

        public int ValueMod { get; set; }
    }
}