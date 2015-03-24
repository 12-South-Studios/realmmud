using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Realm.DAL.Common;

namespace Realm.DAL.Models
{
    [Table("Elements")]
    public class Element : IEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        public int OppositeElementId { get; set; }

        public int LeftElementId { get; set; }

        public int RightElementId { get; set; }

        public DateTime? CreateDateUtc { get; set; }
    }
}