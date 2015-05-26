using System.ComponentModel.DataAnnotations.Schema;
using Realm.DAL.Common;

namespace Realm.DAL.Models
{
    [Table("ItemTreasures")]
    public class ItemTreasure : Entity
    {
        public int ItemId { get; set; }
        public virtual Item Item { get; set; }

        public int? TreasureId { get; set; }
        public virtual Treasure Treasure { get; set; }

        public int Quantity { get; set; }
    }
}