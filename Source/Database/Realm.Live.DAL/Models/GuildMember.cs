using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Realm.DAL.Common;
using Realm.DAL.Enumerations;

namespace Realm.Live.DAL.Models
{
    [Table("GuildMembers")]
    public class GuildMember : Entity
    {
        public int GuildId { get; set; }
        public virtual Guild Guild { get; set; }

        public int? CharacterId;
        public virtual Character Character { get; set; }

        public GuildRankTypes GuildRankType { get; set; }

        public DateTime? JoinedOn { get; set; }

        [MaxLength(255)]
        public string MemberNote { get; set; }
    }
}
