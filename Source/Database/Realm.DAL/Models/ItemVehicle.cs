using System.ComponentModel.DataAnnotations.Schema;
using Realm.DAL.Common;

namespace Realm.DAL.Models
{
    [Table("ItemVehicles")]
    public class ItemVehicle : Entity
    {
        public int ItemId { get; set; }
        public virtual Item Item { get; set; }

        public int MaxCapacity { get; set; }
    }
}