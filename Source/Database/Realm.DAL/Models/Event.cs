using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Realm.DAL.Common;

namespace Realm.DAL.Models
{
    [Table("Events")]
    public class Event : IEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        public bool IsItemEvent { get; set; }

        public bool IsMobileEvent { get; set; }

        public bool IsSpaceEvent { get; set; }

        public DateTime? CreateDateUtc { get; set; }
    }
}