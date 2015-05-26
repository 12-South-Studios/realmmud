using System.ComponentModel.DataAnnotations.Schema;
using Realm.DAL.Common;

namespace Realm.DAL.Models
{
    [Table("ItemPotions")]
    public class ItemPotion : Entity
    {
        public int ItemId { get; set; }
        public virtual Item Item { get; set; }

        public int? AbilityId { get; set; }
        public virtual Ability Ability { get; set; }

        public int Charges { get; set; }

        public int? ColorId { get; set; }
        public virtual Color Color { get; set; }
    }
}