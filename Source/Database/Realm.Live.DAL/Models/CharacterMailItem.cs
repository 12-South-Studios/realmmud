using System.ComponentModel.DataAnnotations.Schema;
using Realm.DAL.Common;

namespace Realm.Live.DAL.Models
{
    [Table("CharacterMailItems")]
    public class CharacterMailItem : Entity
    {
        public Instance Instance { get; set; }

        public int? ItemId { get; set; }

        public int Quantity { get; set; }
    }
}
