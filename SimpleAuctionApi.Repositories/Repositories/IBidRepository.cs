using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SimpleAuctionApi.Repositories.Models;

namespace SimpleAuctionApi.Repositories.Repositories
{
    public interface IBidRepository
    {
        Guid Place(Bid bid);
        Task<List<Bid>> GetAllAsync();
        Task<List<Bid>> GetByAuctionItemIdAsync(int auctionItemId);
        int GetCountByAuctionItemId(int auctionItemId);
        Bid GetLastBidByAuctionItemId(int auctionItemId);
    }
}