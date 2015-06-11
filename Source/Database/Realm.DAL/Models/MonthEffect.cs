using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Realm.DAL.Common;

namespace Realm.DAL.Models
{
    [Table("MonthEffects")]
    public class MonthEffect : IEntity
    {
        [Required]
        public int EffectId { get; set; }
        public virtual Effect Effect { get; set; }

        [Required]
        public int MonthId { get; set; }
        public virtual Month Month { get; set; }

        [Key]
        public int Id { get; set; }

        public DateTime? CreateDateUtc { get; set; }
    }
}