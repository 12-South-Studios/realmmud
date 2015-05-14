using System;
using System.ComponentModel.DataAnnotations.Schema;
using Realm.DAL.Common;

namespace Realm.Live.DAL.Models
{
    [Table("AuctionBids")]
    public class AuctionBid : Entity
    {
        public Character Character { get; set; }

        public DateTime DatePlaced { get; set; }

        public int Amount { get; set; }

        public bool IsRetracted { get; set; }
    }
}
