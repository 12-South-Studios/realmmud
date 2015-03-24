using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Realm.DAL.Common;

namespace Realm.DAL.Models
{
    [Table("ZoneResets")]
    public class ZoneReset : Entity
    {
        public virtual Reset Reset { get; set; }

        [Required]
        public int ZoneId { get; set; }

        [ForeignKey("ZoneId")]
        public Zone Zone { get; set; }
    }
}