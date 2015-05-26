using System.ComponentModel.DataAnnotations.Schema;
using Realm.DAL.Common;

namespace Realm.DAL.Models
{
    [Table("ItemDrinkContainers")]
    public class ItemDrinkContainer : Entity
    {
        public int ItemId { get; set; }
        public virtual Item Item { get; set; }

        public int? LiquidId { get; set; }
        public virtual Liquid Liquid { get; set; }

        public int MaxCharges { get; set; }
    }
}