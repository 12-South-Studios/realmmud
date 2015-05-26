using System.ComponentModel.DataAnnotations.Schema;
using Realm.DAL.Common;

namespace Realm.DAL.Models
{
    [Table("ItemContainers")]
    public class ItemContainer : Entity
    {
        public int ItemId { get; set; }
        public virtual Item Item { get; set; }

        public int WeightAllowance { get; set; }

        public int VolumeAllowance { get; set; }

        public int? LockItemId { get; set; }
        public virtual Item LockItem { get; set; }
    }
}