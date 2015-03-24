using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Realm.DAL.Enumerations;
using Realm.DAL.Common;

namespace Realm.DAL.Models
{
    [Table("MobileStatistics")]
    public class MobileStatistic : Entity
    {
        public Statistic Statistic { get; set; }

        public virtual Skill Skill { get; set; }

        public int Value { get; set; }

        [Required]
        public int MobileId { get; set; }

        [ForeignKey("MobileId")]
        public Mobile Mobile { get; set; }
    }
}