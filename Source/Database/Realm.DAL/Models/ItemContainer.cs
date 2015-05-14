using System.ComponentModel.DataAnnotations.Schema;
using Realm.DAL.Common;

namespace Realm.DAL.Models
{
    [Table("ItemContainers")]
    public class ItemContainer : Entity
    {
        public int WeightAllowance { get; set; }

        public int VolumeAllowance { get; set; }

        public Item LockItem { get; set; }
    }
}