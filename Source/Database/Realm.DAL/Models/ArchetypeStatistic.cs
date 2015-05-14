using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Realm.DAL.Common;
using Realm.DAL.Enumerations;

namespace Realm.DAL.Models
{
    [Table("ArchetypeStatistics")]
    public class ArchetypeStatistic : Entity
    {
        public Statistic Statistic { get; set; }

        public virtual Skill Skill { get; set; }

        public int ModValue { get; set; }

        public bool IsExempt { get; set; }

        [Required]
        public int ArchetypeId { get; set; }

        [ForeignKey("ArchetypeId")]
        public Archetype Archetype { get; set; }
    }
}