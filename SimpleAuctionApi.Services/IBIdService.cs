using System.Collections.Generic;
using System.Threading.Tasks;
using SimpleAuctionApi.Dto;

namespace SimpleAuctionApi.Services
{
    public interface IBidService
    {
        Task<List<BidRequestDto>> GetAllAsync();
        Task<List<BidRequestDto>> GetByAuctionItemId(int auctionItemId);
        Task<BidResponse> Place(BidRequestDto bidRequestDto);
    }
}