using System.ComponentModel.DataAnnotations.Schema;
using Realm.DAL.Common;

namespace Realm.Live.DAL.Models
{
    [Table("CharacterMailItems")]
    public class CharacterMailItem : Entity
    {
        public int CharacterMailId { get; set; }
        public virtual CharacterMail CharacterMail { get; set; }

        public int? InstanceId { get; set; }
        public virtual Instance Instance { get; set; }

        public int? ItemId { get; set; }

        public int Quantity { get; set; }
    }
}
