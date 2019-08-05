using System;

namespace SimpleAuctionApi.Repositories.Models
{
    public class Bid
    {
        public Bid()
        {
            Guid = Guid.NewGuid();
        }

        public Guid Guid { get; set; }
        public DateTime BidTime { get; set; }
        public int AuctionItemId { get; set; }
        public decimal Amount { get; set; }
    }
}
