using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Realm.DAL.Common;

namespace Realm.DAL.Models
{
    [Table("QuestActions")]
    public class QuestAction : Entity
    {
        public bool IsStart { get; set; }

        public int? MobileId { get; set; }
        public virtual Mobile Mobile { get; set; }

        public int Coin { get; set; }

        public int Experience { get; set; }

        public int? GivePrimitiveId { get; set; }
        public virtual Primitive GivePrimitive { get; set; }

        public int? DeletePrimitiveId { get; set; }
        public virtual Primitive DeletePrimitive { get; set; }

        public int Quantity { get; set; }

        public int? MudProgId { get; set; }
        public virtual MudProg MudProg { get; set; }

        public string JournalEntry { get; set; }

        [Required]
        public int QuestId { get; set; }
        public virtual Quest Quest { get; set; }
    }
}