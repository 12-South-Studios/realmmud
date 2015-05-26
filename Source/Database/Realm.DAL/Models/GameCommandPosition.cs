using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Realm.DAL.Common;
using Realm.DAL.Enumerations;

namespace Realm.DAL.Models
{
    [Table("GameCommandPositions")]
    public class GameCommandPosition : Entity
    {
        public PositionTypes PositionType { get; set; }

        [Required]
        public int GameCommandId { get; set; }
        public virtual GameCommand GameCommand { get; set; }
    }
}