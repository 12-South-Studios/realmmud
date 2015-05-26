using System.ComponentModel.DataAnnotations.Schema;
using Realm.DAL.Common;

namespace Realm.DAL.Models
{
    [Table("ItemPortals")]
    public class ItemPortal : Entity
    {
        public int ItemId { get; set; }
        public virtual Item Item { get; set; }

        public int? DestinationId { get; set; }
        public virtual Space Destination { get; set; }
    }
}