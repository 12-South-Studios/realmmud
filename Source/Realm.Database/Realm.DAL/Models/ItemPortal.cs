using System.ComponentModel.DataAnnotations.Schema;
using Realm.DAL.Common;

namespace Realm.DAL.Models
{
    [Table("ItemPortals")]
    public class ItemPortal : Entity
    {
        public Space Destination { get; set; }
    }
}