using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SimpleAuctionApi.Dto;
using SimpleAuctionApi.Services;

namespace SimpleAuctionApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class AuctionController : ControllerBase
    {
        private readonly IAuctionItemService _auctionItemService;

        public AuctionController(IAuctionItemService auctionItemService)
        {
            this._auctionItemService = auctionItemService;
        }

        // GET: api/Auction
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AuctionItemDto>>> Get()
        {
            return await _auctionItemService.GetAllAsync();
        }

        // GET: api/Auction/5
        [HttpGet("{id}", Name = "Get")]
        public async Task<ActionResult<AuctionItemDto>> Get(int id)
        {
            var auctionItem = await _auctionItemService.GetAsync(id);

            if (auctionItem != null)
            {
                return Ok(auctionItem);
            }

            return NotFound();
        }
    }
}
