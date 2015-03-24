using System.ComponentModel.DataAnnotations.Schema;
using Realm.DAL.Common;

namespace Realm.DAL.Models
{
    [Table("ItemMagicalNodes")]
    public class ItemMagicalNode : Entity
    {
        public Effect Effect { get; set; }

        public int Duration { get; set; }
    }
}