using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AuctionItem = SimpleAuctionApi.Repositories.Models.AuctionItem;

namespace SimpleAuctionApi.Repositories.Repositories
{
    public class AuctionRepository : IAuctionRepository
    {
        private List<AuctionItem> _auctionItems = new List<AuctionItem>
        {
            new AuctionItem {
                        Id = 1,
                        Name = "Polar Vantage V Titan",
                        Description = "Premium multisport watch",
                        ImageUrl = "https://www.polar.com/sites/default/files/product2/600x600/polar-vantage-v-titan-600x600.png",
                        StartPrice = 40,
                        EndTime = DateTime.Now.AddDays(30)
                    },
                    new AuctionItem {
                        Id = 2,
                        Name = "Polar Vantage V",
                        Description = "Multisport watch",
                        ImageUrl = "https://www.polar.com/sites/default/files/product2/600x600/polar-vantage-v-black-600x600.png",
                        StartPrice = 30,
                        EndTime = DateTime.Now.AddDays(-1)
                    },
                    new AuctionItem {
                        Id = 3,
                        Name = "Polar Vantage M",
                        Description = "Running watch",
                        ImageUrl = "https://www.polar.com/sites/default/files/product2/600x600/polar-vantage-m-black-600x600.png",
                        StartPrice = 20,
                        EndTime = DateTime.Now.AddDays(20)
                    }
        };

        public Task<AuctionItem> GetAsync(int id)
        {
            return Task.Run(() => _auctionItems.Find(f => f.Id == id));
        }

        public Task<List<AuctionItem>> GetAllAsync()
        {
            return Task.Run(() => _auctionItems);
        }
    }
}
