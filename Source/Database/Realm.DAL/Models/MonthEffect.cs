using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Realm.DAL.Common;

namespace Realm.DAL.Models
{
    [Table("MonthEffects")]
    public class MonthEffect : Entity
    {
        public virtual Effect Effect { get; set; }

        [Required]
        public int MonthId { get; set; }

        [ForeignKey("MonthId")]
        public Month Month { get; set; }
    }
}