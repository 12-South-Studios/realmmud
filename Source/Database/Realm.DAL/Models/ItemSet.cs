using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Realm.DAL.Models
{
    [Table("ItemSets")]
    public class ItemSet : Primitive
    {
        public string DisplayDescription { get; set; }

        public virtual ICollection<ItemSetBonus> Bonuses { get; set; }

        public virtual ICollection<ItemSetItem> Items { get; set; }
    }
}