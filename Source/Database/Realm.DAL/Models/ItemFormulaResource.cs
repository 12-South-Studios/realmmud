using System.ComponentModel.DataAnnotations.Schema;
using Realm.DAL.Common;

namespace Realm.DAL.Models
{
    [Table("ItemFormulaResources")]
    public class ItemFormulaResource : Entity
    {
        public int ItemId { get; set; }
        public virtual Item Item { get; set; }

        public int? ResourceItemId { get; set; }
        public virtual Item ResourceItem { get; set; }

        public int Quantity { get; set; }
    }
}