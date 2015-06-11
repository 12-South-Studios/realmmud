using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Realm.DAL.Enumerations;

namespace Realm.DAL.Models
{
    [Table("Barriers")]
    public class Barrier : IPrimitive
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

        [Required]
        [MaxLength(2048)]
        public string DisplayDescription { get; set; }

        [Required]
        public MaterialTypes MaterialType { get; set; }

        public int Bits { get; set; }

        public int? KeyItemId { get; set; }
        public virtual Item KeyItem { get; set; }

        public int? LockItemId { get; set; }
        public virtual Item LockItem { get; set; }

        public int? TrapItemId { get; set; }
        public virtual Item TrapItem { get; set; }

        public int? TagSetId { get; set; }
        public virtual TagSet TagSet { get; set; }
    }
}