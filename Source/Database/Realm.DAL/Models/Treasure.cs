using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Realm.DAL.Models
{
    [Table("Treasures")]
    public class Treasure : Primitive
    {
        public string SystemDescription { get; set; }

        public virtual ICollection<TreasurePrimitive> Primitives { get; set; }
    }
}