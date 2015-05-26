using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Realm.DAL.Common;

namespace Realm.DAL.Models
{
    [Table("MobileTreasureTables")]
    public class MobileTreasureTable : Entity
    {
        public int? TreasureId { get; set; }
        public virtual Treasure Treasure { get; set; }

        public int MinCoin { get; set; }

        public int MaxCoin { get; set; }

        public int Weight { get; set; }

        public int MaxPulls { get; set; }

        [Required]
        public int MobileId { get; set; }
        public virtual Mobile Mobile { get; set; }
    }
}