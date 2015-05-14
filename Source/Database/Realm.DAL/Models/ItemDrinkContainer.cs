using System.ComponentModel.DataAnnotations.Schema;
using Realm.DAL.Common;

namespace Realm.DAL.Models
{
    [Table("ItemDrinkContainers")]
    public class ItemDrinkContainer : Entity
    {
        public Liquid Liquid { get; set; }

        public int MaxCharges { get; set; }
    }
}