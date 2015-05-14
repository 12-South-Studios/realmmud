using System.ComponentModel.DataAnnotations.Schema;
using Realm.DAL.Common;
using Realm.DAL.Enumerations;

namespace Realm.Live.DAL.Models
{
    [Table("CharacterStatistics")]
    public class CharacterStatistic : Entity
    {
        public Statistic Statistic { get; set; }

        public int? SkillId { get; set; }

        public int Value { get; set; }
    }
}
