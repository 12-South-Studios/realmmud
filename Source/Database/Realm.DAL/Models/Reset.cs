using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Realm.DAL.Enumerations;

namespace Realm.DAL.Models
{
    [Table("Resets")]
    public class Reset : IPrimitive
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

        public ResetTypes ResetType { get; set; }

        public ResetLocationTypes ResetLocationType { get; set; }

        public int? SpaceId { get; set; }
        public virtual Space Space { get; set; }

        public int Limit { get; set; }

        public int Quantity { get; set; }

        public int? ObjectId { get; set; }
        public virtual IPrimitive Object { get; set; }
    }
}