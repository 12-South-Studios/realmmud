using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Realm.DAL.Enumerations;

namespace Realm.DAL.Models
{
    [Table("GameCommands")]
    public class GameCommand : Primitive
    {
        public LogActionTypes LogActionType { get; set; }

        public int Bits { get; set; }

        public int? TagSetId { get; set; }
        public virtual TagSet TagSet { get; set; }

        public string Keywords { get; set; }

        public virtual ICollection<GameCommandPosition> Positions { get; set; }

        public virtual ICollection<GameCommandUserState> UserStates { get; set; }
    }
}