using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Realm.DAL.Common;

namespace Realm.DAL.Models
{
    [Table("RaceHitLocations")]
    public class RaceHitLocation : Entity
    {
        public int? HitLocationId { get; set; }
        public virtual WearLocation HitLocation { get; set; }

        [Required]
        public int RaceId { get; set; }
        public virtual Race Race { get; set; }
    }
}