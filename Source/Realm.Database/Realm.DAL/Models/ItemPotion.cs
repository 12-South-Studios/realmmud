using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Realm.DAL.Common;

namespace Realm.DAL.Models
{
    [Table("ItemPotions")]
    public class ItemPotion : Entity
    {
         public Ability Ability { get; set; }

        public int Charges { get; set; }

        public Color Color { get; set; }
    }
}