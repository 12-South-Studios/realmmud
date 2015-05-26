using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Realm.DAL.Common;
using Realm.DAL.Enumerations;

namespace Realm.DAL.Models
{
    [Table("GameCommandUserStates")]
    public class GameCommandUserState : Entity
    {
        public UserStateTypes UserStateType { get; set; }

        [Required]
        public int GameCommandId { get; set; }
        public virtual GameCommand GameCommand { get; set; }
    }
}