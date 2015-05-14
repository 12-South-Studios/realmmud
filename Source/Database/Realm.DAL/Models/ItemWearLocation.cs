using System.ComponentModel.DataAnnotations.Schema;
using Realm.DAL.Common;

namespace Realm.DAL.Models
{
    [Table("ItemWearLocations")]
    public class ItemWearLocation : Entity
    {
        public WearLocation WornAt { get; set; }
    }
}