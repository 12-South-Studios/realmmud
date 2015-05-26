using System.ComponentModel.DataAnnotations.Schema;
using Realm.DAL.Common;

namespace Realm.Live.DAL.Models
{
    [Table("CharacterFactions")]
    public class CharacterFaction : Entity
    {
        public int CharacterId { get; set; }
        public virtual Character Character { get; set; }

        public int? FactionId { get; set; }

        public int Reputation { get; set; }
    }
}
