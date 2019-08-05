using System;
using System.Collections.Generic;
using SimpleAuctionApi.Dto;

namespace SimpleAuctionApi.Repositories.Models
{
    public class AuctionItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public decimal StartPrice { get; set; }
        public DateTime EndTime { get; set; }
    }
}
