using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Realm.DAL.Common;

namespace Realm.DAL.Models
{
    [Table("RitualReagants")]
    public class RitualReagant : Entity
    {
        public virtual Item ReagantItem { get; set; }

        public int Quantity { get; set; }

        [Required]
        public int RitualId { get; set; }

        [ForeignKey("RitualId")]
        public Ritual Ritual { get; set; }
    }
}