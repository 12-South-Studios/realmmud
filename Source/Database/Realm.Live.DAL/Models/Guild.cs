using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Realm.DAL.Common;

namespace Realm.Live.DAL.Models
{
    [Table("Guilds")]
    public class Guild : Entity
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [MaxLength(1024)]
        public string Description { get; set; }

        [MaxLength(1024)]
        public string Motd { get; set; }

        [MaxLength(50)]
        public string Url { get; set; }

        public int MemberLimit { get; set; }

        public int? MemberChannelId { get; set; }
        public virtual Channel MemberChannel { get; set; }

        public int? OfficerChannelId { get; set; }
        public virtual Channel OfficerChannel { get; set; }

        public int Level { get; set; }

        public int Experience { get; set; }

        public virtual ICollection<GuildAbility> Abilities { get; set; }

        public virtual ICollection<GuildMember> Members { get; set; }

        public int? BankId { get; set; }
        public virtual Bank Bank { get; set; } 
    }
}
