using System.ComponentModel.DataAnnotations.Schema;
using Realm.DAL.Common;

namespace Realm.DAL.Models
{
    [Table("ItemMudProgs")]
    public class ItemMudProg : Entity
    {
        public int ItemId { get; set; }
        public virtual Item Item { get; set; }

        public int? EventId { get; set; }
        public virtual Event Event { get; set; }

        public int? MudProgId { get; set; }
        public virtual MudProg MudProg { get; set; }

        public float PercentChance { get; set; }
    }
}