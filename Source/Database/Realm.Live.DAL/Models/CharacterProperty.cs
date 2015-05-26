using System.ComponentModel.DataAnnotations.Schema;
using Realm.DAL.Common;

namespace Realm.Live.DAL.Models
{
    [Table("CharacterProperties")]
    public class CharacterProperty : Entity
    {
        public int CharacterId { get; set; }
        public virtual Character Character { get; set; }

        public int? PropertyId { get; set; }
        public Property Property { get; set; }

        public string value { get; set; }
    }
}
