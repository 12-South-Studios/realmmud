using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Realm.DAL.Common;

namespace Realm.DAL.Models
{
    [Table("ItemBooks")]
    public class ItemBook : Entity
    {
        public SystemString Text { get; set; }

        public Ability Ability { get; set; }
    }
}