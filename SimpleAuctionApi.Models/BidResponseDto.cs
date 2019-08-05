using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace SimpleAuctionApi.Dto
{
    public class BidResponseDto
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public BidRequestDto BidRequestDto { get; set; }
    }
}