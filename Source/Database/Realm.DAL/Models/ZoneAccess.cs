using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using Realm.DAL.Common;

namespace Realm.DAL.Models
{
    [Table("ZoneAccesses")]
    public class ZoneAccess : Entity
    {
        [Required]
        public string AccessName { get; set; }

        public int AccessValue { get; set; }

        [Required]
        public int ZoneId { get; set; }
        public virtual Zone Zone { get; set; }
    }
}