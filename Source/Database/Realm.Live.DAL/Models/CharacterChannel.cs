using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Realm.DAL.Common;

namespace Realm.Live.DAL.Models
{
    [Table("CharacterChannels")]
    public class CharacterChannel : Entity
    {
        public int CharacterId { get; set; }
        public virtual Character Character { get; set; }

        public int? ChannelId { get; set; }
        public virtual Channel Channel { get; set; }

        [MaxLength(10)]
        public string Handle { get; set; }

        public bool IsEnabled { get; set; }
    }
}
