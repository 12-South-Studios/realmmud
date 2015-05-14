using System.ComponentModel.DataAnnotations.Schema;
using Realm.DAL.Common;

namespace Realm.DAL.Models
{
    [Table("ItemVehicleTerrains")]
    public class ItemVehicleTerrain : Entity
    {
        public Terrain Terrain { get; set; }
    }
}