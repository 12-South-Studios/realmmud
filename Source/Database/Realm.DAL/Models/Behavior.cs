using System.ComponentModel.DataAnnotations.Schema;

namespace Realm.DAL.Models
{
    [Table("Behaviors")]
    public class Behavior : Primitive
    {
        public int Bits { get; set; }

        public int? TagSetId { get; set; }
        public virtual TagSet TagSet { get; set; }
    }
}