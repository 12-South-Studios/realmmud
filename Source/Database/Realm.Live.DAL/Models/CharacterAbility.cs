using System;
using System.ComponentModel.DataAnnotations.Schema;
using Realm.DAL.Common;

namespace Realm.Live.DAL.Models
{
    [Table("CharacterAbilities")]
    public class CharacterAbility : Entity
    {
        public int CharacterId { get; set; }
        public virtual Character Character { get; set; }

        public int? AbilityId { get; set; }

        public DateTime? PurchasedOn { get; set; }
    }
}
