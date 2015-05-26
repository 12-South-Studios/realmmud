using System.ComponentModel.DataAnnotations.Schema;
using Realm.DAL.Common;

namespace Realm.DAL.Models
{
    [Table("ItemBooks")]
    public class ItemBook : Entity
    {
        public int ItemId { get; set; }
        public virtual Item Item { get; set; }

        public string Text { get; set; }

        public int? AbilityId { get; set; }
        public virtual Ability Ability { get; set; }
    }
}