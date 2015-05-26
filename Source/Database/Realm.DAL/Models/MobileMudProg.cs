using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Realm.DAL.Common;

namespace Realm.DAL.Models
{
    [Table("MobileMudProgs")]
    public class MobileMudProg : Entity
    {
        public int? EventId { get; set; }
        public virtual Event Event { get; set; }

        public int? MudProgId { get; set; }
        public virtual MudProg MudProg { get; set; }

        public float PercentChance { get; set; }

        [Required]
        public int MobileId { get; set; }
        public virtual Mobile Mobile { get; set; }
    }
}