using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Realm.DAL.Common;
using Realm.DAL.Enumerations;

namespace Realm.DAL.Models
{
    [Table("EffectStatMods")]
    public class EffectStatMod : Entity
    {
        public Statistic AffectedStatistic { get; set; }

        public int? AffectedSkillId { get; set; }
        public virtual Skill AffectedSkill { get; set; }

        public int? ElementId { get; set; }
        public virtual Element Element { get; set; }

        public int MinValue { get; set; }

        public int MaxValue { get; set; }

        [Required]
        public int EffectId { get; set; }
        public virtual Effect Effect { get; set; }
    }
}