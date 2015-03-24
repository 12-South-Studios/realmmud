using System.ComponentModel.DataAnnotations.Schema;
using Realm.DAL.Common;

namespace Realm.DAL.Models
{
    [Table("ItemSetItems")]
    public class ItemSetItem : Entity
    {
        public virtual Item Item { get; set; }
    }
}