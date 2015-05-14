using System.ComponentModel.DataAnnotations.Schema;
using Realm.DAL.Common;
using Realm.DAL.Enumerations;

namespace Realm.DAL.Models
{
    [Table("ItemLights")]
    public class ItemLight : Entity
    {
        public FuelTypes FuelType { get; set; }

        public Item FuelItem { get; set; }

        public int Charges { get; set; }

        public int BurnRate { get; set; }
    }
}