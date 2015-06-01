using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Realm.DAL.Models
{
    [Table("Factions")]
    public class Faction : Primitive
    {
        public int? TagSetId { get; set; }
        public virtual TagSet TagSet { get; set; }

        public virtual ICollection<FactionRelation> Relations { get; set; }
    }
}