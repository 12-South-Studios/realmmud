using System;
using System.ComponentModel.DataAnnotations.Schema;
using Realm.DAL.Common;

namespace Realm.Live.DAL.Models
{
    [Table("CharacterAuctions")]
    public class CharacterAuction : Entity
    {
        public int CharacterId { get; set; }
        public virtual Character Character { get; set; }

        public Int64? AuctionId { get; set; }
        public virtual Auction Auction { get; set; }
    }
}
