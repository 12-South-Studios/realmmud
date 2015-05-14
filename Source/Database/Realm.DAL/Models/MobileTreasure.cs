using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Realm.DAL.Common;

namespace Realm.DAL.Models
{
    [Table("MobileTreasures")]
    public class MobileTreasure : Entity
    {
        public int MinPulls { get; set; }

        public int MaxPulls { get; set; }

        [Required]
        public int MobileId { get; set; }

        [ForeignKey("MobileId")]
        public Mobile Mobile { get; set; }
    }
}