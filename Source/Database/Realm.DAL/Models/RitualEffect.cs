using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Realm.DAL.Enumerations;
using Realm.DAL.Common;

namespace Realm.DAL.Models
{
    [Table("RitualEffects")]
    public class RitualEffect : Entity
    {
        public virtual Effect Effect { get; set; }

        public TargetClassTypes TargetClassType { get; set; }

        public int Bits { get; set; }

        [Required]
        public int RitualId { get; set; }
        
        [ForeignKey("RitualId")]
        public Ritual Ritual { get; set; }
    }
}