using System.Collections.Generic;
using System.Threading.Tasks;
using SimpleAuctionApi.Dto;

namespace SimpleAuctionApi.Services
{
    public interface IAuctionItemService
    {
        Task<List<AuctionItemDto>> GetAllAsync();
        Task<AuctionItemDto> GetAsync(int id);
    }
}