using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Realm.DAL.Enumerations;

namespace Realm.Live.DAL.Models
{
    [Table("Instances")]
    public class Instance 
    {
        [Key]
        public Int64 Id { get; set; }

        [Required]
        public DateTime CreatedOn { get; set; }

        [Required]
        public InstanceTypes InstanceType { get; set; }
    }
}
