using System.ComponentModel.DataAnnotations.Schema;
using Realm.DAL.Common;

namespace Realm.DAL.Models
{
    [Table("ItemMagicalNodes")]
    public class ItemMagicalNode : Entity
    {
        public int ItemId { get; set; }
        public virtual Item Item { get; set; }

        public int? EffectId { get; set; }
        public virtual Effect Effect { get; set; }

        public int Duration { get; set; }
    }
}