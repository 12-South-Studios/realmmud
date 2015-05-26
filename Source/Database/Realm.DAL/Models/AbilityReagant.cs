using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Realm.DAL.Common;

namespace Realm.DAL.Models
{
    [Table("AbilityReagants")]
    public class AbilityReagant : Entity
    {
        public int? ItemId { get; set; }
        public virtual Item Item { get; set; }

        public int Quantity { get; set; }

        [Required]
        public int AbilityId { get; set; }
        public virtual Ability Ability { get; set; }
    }
}