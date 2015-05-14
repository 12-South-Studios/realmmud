using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Realm.DAL.Common;
using Realm.DAL.Enumerations;

namespace Realm.DAL.Models
{
    [Table("EffectPositions")]
    public class EffectPosition : Entity
    {
        public PositionTypes PositionType { get; set; }

        [Required]
        public int EffectId { get; set; }

        [ForeignKey("EffectId")]
        public Effect Effect { get; set; }
    }
}