using System.ComponentModel.DataAnnotations.Schema;
using Realm.DAL.Common;

namespace Realm.DAL.Models
{
    [Table("ItemTreasures")]
    public class ItemTreasure : Entity
    {
        public Treasure Treasure { get; set; }

        public int Quantity { get; set; }
    }
}