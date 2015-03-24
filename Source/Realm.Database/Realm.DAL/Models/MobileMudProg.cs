using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Realm.DAL.Common;

namespace Realm.DAL.Models
{
    [Table("MobileMudProgs")]
    public class MobileMudProg : Entity
    {
        public virtual Event Event { get; set; }

        public virtual MudProg MudProg { get; set; }

        public float PercentChance { get; set; }

        [Required]
        public int MobileId { get; set; }

        [ForeignKey("MobileId")]
        public Mobile Mobile { get; set; }
    }
}