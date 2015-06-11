using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Realm.DAL.Models
{
    [Table("Treasures")]
    public class Treasure : IPrimitive
    {
        [Key]
        public int Id { get; set; }

        public DateTime? CreateDateUtc { get; set; }

        [Required]
        [MaxLength(255), MinLength(5)]
        public string SystemName { get; set; }

        [Required]
        public int? SystemClassId { get; set; }
        public virtual SystemClass SystemClass { get; set; }

        [Required]
        [MaxLength(255), MinLength(5)]
        public string DisplayName { get; set; }

        public virtual ICollection<TreasurePrimitive> Primitives { get; set; }
    }
}