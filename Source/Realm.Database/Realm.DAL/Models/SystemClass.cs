using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Realm.DAL.Enumerations;
using Realm.DAL.Common;

namespace Realm.DAL.Models
{
    [Table("SystemClasses")]
    public class SystemClass : IEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public virtual int Id { get; set; }

        [MaxLength(50)]
        public string Name { get; set; }

        public int? ParentClassId { get; set; }

        [ForeignKey("ParentClassId")]
        public SystemClass ParentClass { get; set; }

        public SystemTypes SystemType { get; set; }

        public DateTime? CreateDateUtc { get; set; }
    }
}