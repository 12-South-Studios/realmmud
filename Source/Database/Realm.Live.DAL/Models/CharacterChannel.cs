using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Realm.DAL.Common;

namespace Realm.Live.DAL.Models
{
    [Table("CharacterChannels")]
    public class CharacterChannel : Entity
    {
        public Channel Channel { get; set; }

        [MaxLength(10)]
        public string Handle { get; set; }

        public bool IsEnabled { get; set; }
    }
}
