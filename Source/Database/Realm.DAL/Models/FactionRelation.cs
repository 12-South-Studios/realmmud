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
        public virtual Faction TargetFaction { get; set; }

        public FactionRelationshipTypes FactionRelationshipType { get; set; }

        [Required]
        public int FactionId { get; set; }
        public virtual Faction Faction { get; set; }
    }
}