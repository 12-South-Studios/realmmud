using System.ComponentModel.DataAnnotations.Schema;
using Realm.DAL.Common;

namespace Realm.DAL.Models
{
    [Table("ItemWearLocations")]
    public class ItemWearLocation : Entity
    {
        public int ItemId { get; set; }
        public virtual Item Item { get; set; }

        public int? WornAtId { get; set; }
        public virtual WearLocation WornAt { get; set; }
    }
}