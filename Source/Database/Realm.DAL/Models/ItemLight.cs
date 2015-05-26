using System.ComponentModel.DataAnnotations.Schema;
using Realm.DAL.Common;
using Realm.DAL.Enumerations;

namespace Realm.DAL.Models
{
    [Table("ItemLights")]
    public class ItemLight : Entity
    {
        public int ItemId { get; set; }
        public virtual Item Item { get; set; }

        public FuelTypes FuelType { get; set; }

        public int? FuelItemId { get; set; }
        public virtual Item FuelItem { get; set; }

        public int Charges { get; set; }

        public int BurnRate { get; set; }
    }
}