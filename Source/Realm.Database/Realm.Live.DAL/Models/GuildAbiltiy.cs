using System;
using System.ComponentModel.DataAnnotations.Schema;
using Realm.DAL.Common;

namespace Realm.Live.DAL.Models
{
    [Table("GuildAbilities")]
    public class GuildAbility : Entity
    {
        public int? AbilityId { get; set; }

        public DateTime UnlockedOn { get; set; }
    }
}
