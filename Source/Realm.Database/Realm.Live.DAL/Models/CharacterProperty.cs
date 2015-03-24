using System.ComponentModel.DataAnnotations.Schema;
using Realm.DAL.Common;

namespace Realm.Live.DAL.Models
{
    [Table("CharacterProperties")]
    public class CharacterProperty : Entity
    {
        public Property Property { get; set; }

        public string value { get; set; }
    }
}
