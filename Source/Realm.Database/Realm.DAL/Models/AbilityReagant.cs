using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Realm.DAL.Common;

namespace Realm.DAL.Models
{
    [Table("AbilityReagants")]
    public class AbilityReagant : Entity
    {
        public virtual Item Item { get; set; }

        public int Quantity { get; set; }

        [Required]
        public int AbilityId { get; set; }

        [ForeignKey("AbilityId")]
        public virtual Ability Ability { get; set; }
    }
}