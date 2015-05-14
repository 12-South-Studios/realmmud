using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Realm.DAL.Common;

namespace Realm.DAL.Models
{
    [Table("Colors")]
    public class Color : IEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [MaxLength(2)]
        public string Ascii { get; set; }

        [MaxLength(10)]
        public string Escape { get; set; }

        public DateTime? CreateDateUtc { get; set; }
    }
}