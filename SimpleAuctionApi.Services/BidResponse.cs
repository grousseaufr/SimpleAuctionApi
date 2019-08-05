using SimpleAuctionApi.Dto;

namespace SimpleAuctionApi.Services
{
    public class BidResponse
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public int CurrentBidCount { get; set; }
        public BidRequestDto bidDto { get; set; }
    }
}
