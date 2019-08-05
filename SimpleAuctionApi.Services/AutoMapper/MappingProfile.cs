using AutoMapper;
using SimpleAuctionApi.Dto;
using SimpleAuctionApi.Repositories.Models;

namespace SimpleAuctionApi.Services.AutoMapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<AuctionItem, AuctionItemDto>();
            CreateMap<Bid, BidRequestDto>();
            CreateMap<BidRequestDto, Bid>();
        }
    }
}