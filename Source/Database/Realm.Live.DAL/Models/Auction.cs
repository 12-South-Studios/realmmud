using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Realm.DAL.Common;

namespace Realm.Live.DAL.Models
{
    [Table("Auctions")]
    public class Auction : Entity
    {
        public Instance Instance { get; set; }

        public int? ItemId { get; set; }

        public int Quantity { get; set; }

        public Character Character { get; set; }

        public int DurationInSeconds { get; set; }

        public int Reserve { get; set; }

        public bool IsFinished { get; set; }

        public virtual ICollection<AuctionBid> Bids { get; set; }
    }
}
