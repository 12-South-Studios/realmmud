using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Realm.DAL.Models
{
    [Table("Rituals")]
    public class Ritual : Primitive
    {
        [Required]
        public string DisplayDescription { get; set; }

        public int? MagicalNodeItemId { get; set; }
        public virtual Item MagicalNodeItem { get; set; }

        public int CastTime { get; set; }

        public int? TagSetId { get; set; }
        public virtual TagSet TagSet { get; set; }

        public virtual ICollection<RitualEffect> Effects { get; set; }
            
        public virtual ICollection<RitualParticipant> Participants { get; set; }

        public virtual ICollection<RitualReagant> Reagants { get; set; }

        public virtual ICollection<RitualRequirement> Requirements { get; set; }
    }
}