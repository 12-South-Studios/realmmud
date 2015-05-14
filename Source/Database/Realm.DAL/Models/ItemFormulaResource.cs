using System.ComponentModel.DataAnnotations.Schema;
using Realm.DAL.Common;

namespace Realm.DAL.Models
{
    [Table("ItemFormulaResources")]
    public class ItemFormulaResource : Entity
    {
        public Item ResourceItem { get; set; }

        public int Quantity { get; set; }
    }
}