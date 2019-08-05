using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SimpleAuctionApi.Repositories.Models;

namespace SimpleAuctionApi.Repositories.Repositories
{
    public class BidRepository : IBidRepository
    {
        private List<Bid> _bidList = new List<Bid>
        {
            new Bid {
                Guid = Guid.NewGuid(),
                BidTime = DateTime.Now.AddHours(-1),
                Amount = 45,
                AuctionItemId = 1
            },
            new Bid {
                Guid = Guid.NewGuid(),
                BidTime = DateTime.Now.AddHours(-1),
                Amount = 35,
                AuctionItemId = 2
            }
        };


        public Guid Place(Bid bid)
        {
            try
            {
                bid.Guid = Guid.NewGuid();
                _bidList.Add(bid);

                return bid.Guid;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            
        }

        public async Task<List<Bid>> GetAllAsync()
        {
            return await Task.Run(() => _bidList); ;
        }

        public int GetCountByAuctionItemId(int auctionItemId)
        {
            return _bidList.Count(w => w.AuctionItemId == auctionItemId);
        }

        public async Task<List<Bid>> GetByAuctionItemIdAsync(int auctionItemId)
        {
            if (_bidList.Any(a => a.AuctionItemId == auctionItemId))
            {
                return await Task.Run(() => _bidList.Where(s => s.AuctionItemId == auctionItemId).ToList());
            }

            return null;
        }

        public Bid GetLastBidByAuctionItemId(int auctionItemId)
        {
            if (_bidList.Any(a => a.AuctionItemId == auctionItemId))
            {
                return _bidList.Where(s => s.AuctionItemId == auctionItemId).OrderByDescending(o => o.Amount).First();
            }

            return null;
        }
    }
}
