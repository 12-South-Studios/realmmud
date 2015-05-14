using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Realm.DAL.Common;
using Realm.DAL.Enumerations;

namespace Realm.DAL.Models
{
    [Table("FactionRelations")]
    public class FactionRelation : Entity
    {
        public int? TargetFactionId { get; set; }

        [ForeignKey("TargetFactionId")]
        public virtual Faction TargetFaction { get; set; }

        public FactionRelationshipTypes FactionRelationshipType { get; set; }

        [Required]
        public int FactionId { get; set; }

        [ForeignKey("FactionId")]
        public Faction Faction { get; set; }
    }
}