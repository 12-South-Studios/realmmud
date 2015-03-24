using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Realm.DAL.Common;

namespace Realm.DAL.Models
{
    [Table("RitualParticipants")]
    public class RitualParticipant : Entity
    {
        public virtual Item FocusItem { get; set; }

        public virtual WearLocation WearLocation { get; set; }

        [Required]
        public int RitualId { get; set; }

        [ForeignKey("RitualId")]
        public Ritual Ritual { get; set; }
    }
}