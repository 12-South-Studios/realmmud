using System.ComponentModel.DataAnnotations.Schema;
using Realm.DAL.Common;

namespace Realm.DAL.Models
{
    [Table("GuildAbilities")]
    public class GuildAbilityUpgrade : Entity
    {
        public virtual Ability Ability { get; set; }

        public int Cost { get; set; }

        public int RequiredLevel { get; set; }
    }
}