using System.ComponentModel.DataAnnotations.Schema;
using Realm.DAL.Common;

namespace Realm.DAL.Models
{
    [Table("ItemFoods")]
    public class ItemFood : Entity
    {
        public int HungerPoints { get; set; }

        public int Charges { get; set; }

        public int TimeFoodIsEdibleInSeconds { get; set; }

        public int TimeFoodIsDecayingInSeconds { get; set; }

        public SystemString DecayDescription { get; set; }
    }
}