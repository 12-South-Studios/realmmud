using System.ComponentModel.DataAnnotations.Schema;
using Realm.DAL.Common;

namespace Realm.Live.DAL.Models
{
    [Table("CharacterAuctions")]
    public class CharacterAuction : Entity
    {
        public Auction Auction { get; set; }
    }
}
