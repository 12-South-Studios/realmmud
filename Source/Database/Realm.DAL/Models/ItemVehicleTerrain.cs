using System.ComponentModel.DataAnnotations.Schema;
using Realm.DAL.Common;

namespace Realm.DAL.Models
{
    [Table("ItemVehicleTerrains")]
    public class ItemVehicleTerrain : Entity
    {
        public int ItemVehicleId { get; set; }
        public virtual ItemVehicle ItemVehicle { get; set; }

        public int? TerrainId { get; set; }
        public virtual Terrain Terrain { get; set; }
    }
}