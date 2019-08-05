using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Internal;
using SimpleAuctionApi.Dto;
using SimpleAuctionApi.Extensions;
using SimpleAuctionApi.Services;

namespace SimpleAuctionApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class BidController : ControllerBase
    {
        private readonly IBidService _bidService;

        public BidController(IBidService bidService)
        {
            this._bidService = bidService;
        }

        // GET: api/Auction
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BidRequestDto>>> Get()
        {

            return await _bidService.GetAllAsync();
        }

        // POST: api/Auction
        [HttpPost]
        public async Task<ActionResult<BidResponse>> PostAsync([FromBody] BidRequestDto bidRequestDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.GetErrorMessages());
            }

            var bidResponse = await _bidService.Place(bidRequestDto);

            if (!bidResponse.Success)
            {
                return BadRequest(bidResponse.Message);
            }

            return Ok(bidResponse);
        }
    }
}
