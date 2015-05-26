using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Realm.DAL.Common;

namespace Realm.DAL.Models
{
    [Table("MonthEffects")]
    public class MonthEffect : Entity
    {
        public int? EffectId { get; set; }
        public virtual Effect Effect { get; set; }

        [Required]
        public int MonthId { get; set; }
        public virtual Month Month { get; set; }
    }
}