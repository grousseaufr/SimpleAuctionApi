using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using SimpleAuctionApi.Dto;
using SimpleAuctionApi.Repositories.Models;
using SimpleAuctionApi.Repositories.Repositories;

namespace SimpleAuctionApi.Services
{
    public class BidService : IBidService
    {
        private readonly IBidRepository _bidRepository;
        private readonly IAuctionRepository _auctionRepository;
        private readonly IMapper _mapper;

        public BidService(IBidRepository bidRepository, IAuctionRepository auctionRepository, IMapper mapper)
        {
            _bidRepository = bidRepository;
            _auctionRepository = auctionRepository;
            _mapper = mapper;
        }

        public async Task<List<BidRequestDto>> GetAllAsync()
        {
            var bidList = await _bidRepository.GetAllAsync();
            return _mapper.Map<List<Bid>, List<BidRequestDto>>(bidList);
        }

        public async Task<List<BidRequestDto>> GetByAuctionItemId(int auctionItemId)
        {
            var bidList = await _bidRepository.GetByAuctionItemIdAsync(auctionItemId);
            return _mapper.Map<List<Bid>, List<BidRequestDto>>(bidList);
        }

        public async Task<BidResponse> Place(BidRequestDto bidRequestDto)
        {
            var bidResponse = await ValidateBid(bidRequestDto);

            if (!bidResponse.Success) return bidResponse;

            try
            {
                var bid = _mapper.Map<BidRequestDto, Bid>(bidRequestDto);
                var bidGuid = await Task.Run(() => _bidRepository.Place(bid));

                var responseBidDto = _mapper.Map<Bid, BidRequestDto>(bid);
                responseBidDto.Guid = bidGuid;

                bidResponse.bidDto = responseBidDto;
                bidResponse.CurrentBidCount = _bidRepository.GetCountByAuctionItemId(bidRequestDto.AuctionItemId);
                bidResponse.Message = $"${bidRequestDto.Amount} bid received.";

                return bidResponse;
            }
            catch (Exception e)
            {
                return new BidResponse
                {
                    Success = false,
                    Message = $"An error occurred while placing bid : {e.Message}"
                };
            }
        }

        private async Task<BidResponse> ValidateBid(BidRequestDto bidRequestDto)
        {
            var auctionItem = await _auctionRepository.GetAsync(bidRequestDto.AuctionItemId);
            var lastBidItem = _bidRepository.GetLastBidByAuctionItemId(bidRequestDto.AuctionItemId);

            if (auctionItem == null)
            {
                return new BidResponse
                {
                    Success = false,
                    Message = "Cannot find auction item."
                };
            }

            if (bidRequestDto.Amount == 0)
            {
                return new BidResponse
                {
                    Success = false,
                    Message = "Bid amount is required."
                };
            }

            if (lastBidItem != null && bidRequestDto.Amount <= lastBidItem.Amount)
            {
                return new BidResponse
                {
                    Success = false,
                    Message = $"Last bid amount is ${lastBidItem.Amount}. Please bid higher."
                };
            }

            if (bidRequestDto.Amount <= auctionItem.StartPrice)
            {
                return new BidResponse
                {
                    Success = false,
                    Message = $"Start price for this item is ${auctionItem.StartPrice}."
                };
            }

            if (auctionItem.EndTime < bidRequestDto.BidTime)
            {
                return new BidResponse
                {
                    Success = false,
                    Message = "This auction is closed."
                };
            }

            return new BidResponse
            {
                Success = true
            };
        }
    }
}