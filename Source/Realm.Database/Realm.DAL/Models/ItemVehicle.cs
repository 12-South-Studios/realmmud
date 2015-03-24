using System.ComponentModel.DataAnnotations.Schema;
using Realm.DAL.Common;

namespace Realm.DAL.Models
{
    [Table("ItemVehicles")]
    public class ItemVehicle : Entity
    {
        public int MaxCapacity { get; set; }
    }
}