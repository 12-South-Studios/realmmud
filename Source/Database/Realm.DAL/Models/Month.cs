using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Realm.DAL.Enumerations;

namespace Realm.DAL.Models
{
    [Table("Months")]
    public class Month : IPrimitive
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(255), MinLength(4)]
        public string SystemName { get; set; }

        [Required]
        public int? SystemClassId { get; set; }
        public virtual SystemClass SystemClass { get; set; }

        [Required]
        [MaxLength(255), MinLength(4)]
        public string DisplayName { get; set; }

        public DateTime? CreateDateUtc { get; set; }

        [Required]
        public int NumberDays { get; set; }

        [Required]
        public SeasonTypes SeasonType { get; set; }

        [Required]
        public bool IsShrouding { get; set; }

        [Required]
        public int SortOrder { get; set; }

        public virtual ICollection<MonthEffect> Effects { get; set; }
    }
}