using System;
using Moq;
using NUnit.Framework;
using SimpleAuctionApi.Controllers;
using SimpleAuctionApi.Dto;
using SimpleAuctionApi.Repositories.Repositories;
using SimpleAuctionApi.Services;

namespace Tests
{
    [TestFixture]
    public class BidServiceTest
    {
        [SetUp]
        public void Setup()
        {
            
        }

        [Test]
        public async void Test1()
        {

            var mockBidService = new Mock<IBidService>();
            mockBidService.Setup(s => s.Place(new BidRequestDto
            {
                Amount = 60,
                AuctionItemId = 1,
                BidTime = DateTime.Now
            })).ReturnsAsync(new BidResponse
            {
                BidRequestDto = new BidRequestDto
                {
                    Amount = 60,
                    AuctionItemId = 1,
                    BidTime = DateTime.Now
                },
                CurrentBidCount = 2,
                Message = "Ok",
                Success = true
            });

            var controller = new BidController(mockBidService.Object);
            //await controller.PostAsync(new BidRequestDto
            //{
            //    Amount = 60,
            //    AuctionItemId = 1,
            //    BidTime = DateTime.Now
            //}).Result;
        }

        
    }
}