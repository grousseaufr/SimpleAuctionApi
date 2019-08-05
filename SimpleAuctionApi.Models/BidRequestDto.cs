using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace SimpleAuctionApi.Dto
{
    public class BidRequestDto
    {
        public Guid? Guid { get; set; }

        [Required(ErrorMessage = "BidTime is required.")]
        public DateTime BidTime { get; set; }

        [Required(ErrorMessage = "AuctionItemId is required.")]
        public int AuctionItemId { get; set; }

        [Required(ErrorMessage = "Bid amount is required.")]
        public decimal Amount { get; set; }
    }
}