using System.ComponentModel.DataAnnotations.Schema;
using Realm.DAL.Common;
using Realm.DAL.Enumerations;

namespace Realm.DAL.Models
{
    [Table("ItemTools")]
    public class ItemTool : Entity
    {
        public int ItemId { get; set; }
        public virtual Item Item { get; set; }

        public ToolTypes ToolType { get; set; }
    }
}