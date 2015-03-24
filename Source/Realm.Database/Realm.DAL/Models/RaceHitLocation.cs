using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Realm.DAL.Common;

namespace Realm.DAL.Models
{
    [Table("RaceHitLocations")]
    public class RaceHitLocation : Entity
    {
        public virtual WearLocation HitLocation { get; set; }

        [Required]
        public int RaceId { get; set; }

        [ForeignKey("RaceId")]
        public Race Race { get; set; }
    }
}