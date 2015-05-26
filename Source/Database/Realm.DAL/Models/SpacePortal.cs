using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using Realm.DAL.Enumerations;
using Realm.DAL.Common;

namespace Realm.DAL.Models
{
    [Table("SpacePortals")]
    public class SpacePortal : Entity
    {
        public DirectionTypes Direction { get; set; }

        public int? TargetSpaceId { get; set; }
        public virtual Space TargetSpace { get; set; }

        public int? BarrierId { get; set; }
        public virtual Barrier Barrier { get; set; }

        public int Bits { get; set; }

        [Required]
        public string Keywords { get; set; }
    }
}