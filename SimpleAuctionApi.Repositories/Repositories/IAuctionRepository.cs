using System.Collections.Generic;
using System.Threading.Tasks;
using AuctionItem = SimpleAuctionApi.Repositories.Models.AuctionItem;

namespace SimpleAuctionApi.Repositories.Repositories
{
    public interface IAuctionRepository
    {
        Task<List<AuctionItem>> GetAllAsync();
        Task<AuctionItem> GetAsync(int id);
    }
}