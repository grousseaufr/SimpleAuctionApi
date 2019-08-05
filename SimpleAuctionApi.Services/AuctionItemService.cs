using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using SimpleAuctionApi.Dto;
using SimpleAuctionApi.Repositories.Models;
using SimpleAuctionApi.Repositories.Repositories;

namespace SimpleAuctionApi.Services
{
    public class AuctionItemService : IAuctionItemService
    {
        private readonly IAuctionRepository _auctionRepository;
        private readonly IBidService _bidService;
        private readonly IMapper _mapper;

        public AuctionItemService (IAuctionRepository auctionRepository, IBidService bidService, IMapper mapper)
        {
            this._auctionRepository = auctionRepository;
            _bidService = bidService;
            _mapper = mapper;
        }

        public async Task<List<AuctionItemDto>> GetAllAsync()
        {
            var auctionItems = await _auctionRepository.GetAllAsync();
            var auctionItemsDtos = _mapper.Map<List<AuctionItem>, List<AuctionItemDto>>(auctionItems);

            foreach (var auctionItemsDto in auctionItemsDtos)
            {
                auctionItemsDto.BidRequests = await _bidService.GetByAuctionItemId(auctionItemsDto.Id);
            }

            return auctionItemsDtos;
        }

        public async Task<AuctionItemDto> GetAsync(int id)
        {
            var auctionItem = await _auctionRepository.GetAsync(id);
            var auctionItemDto = _mapper.Map<AuctionItem, AuctionItemDto>(auctionItem);
            auctionItemDto.BidRequests = await _bidService.GetByAuctionItemId(auctionItem.Id);

            return auctionItemDto;
        }

    }
}
