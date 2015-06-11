using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Realm.DAL.Common;

namespace Realm.DAL.Models
{
    [Table("ZoneSpaces")]
    public class ZoneSpace : IEntity
    {
        [Required]
        public int SpaceId { get; set; }
        public virtual Space Space { get; set; }

        [Required]
        public int ZoneId { get; set; }
        public virtual Zone Zone { get; set; }

        [Key]
        public int Id { get; set; }

        public DateTime? CreateDateUtc { get; set; }
    }
}