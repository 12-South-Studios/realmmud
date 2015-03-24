using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Realm.DAL.Common;

namespace Realm.Live.DAL.Models
{
    [Table("Channels")]
    public class Channel : Entity
    {
        [Required]
        [MaxLength(20)]
        public string Name { get; set; }

        public ChannelTypes ChannelType { get; set; }

        public int Bits { get; set; }

        public Character Owner { get; set; }
    }
}
