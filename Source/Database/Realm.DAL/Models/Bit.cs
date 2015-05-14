using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Realm.DAL.Common;
using Realm.DAL.Enumerations;

namespace Realm.DAL.Models
{
    [Table("Bits")]
    public class Bit : IEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public virtual int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        public int Value { get; set; }

        public BitTypes BitType { get; set; }

        [MaxLength(1024)]
        public string Description { get; set; }

        [MaxLength(255)]
        public string UniqueGroup { get; set; }

        public DateTime? CreateDateUtc { get; set; }
    }
}