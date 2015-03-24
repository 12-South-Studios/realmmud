using System.ComponentModel.DataAnnotations.Schema;
using Realm.DAL.Common;

namespace Realm.DAL.Models
{
    [Table("ItemFurnitures")]
    public class ItemFurniture : Entity
    {
        public int MaxCapacity { get; set; }
    }
}