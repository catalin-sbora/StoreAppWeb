using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StoraAppWeb.AppServices;
using StoreAppWeb.AppServices.DataModel;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StoreAppWeb.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StockController : StoreWebControllerBase
    {
        private readonly StockService stockService;
        public StockController(StockService stockService)
        {
            this.stockService = stockService;
        }
        [HttpGet]
        [AllowAnonymous]
        public async Task<IEnumerable<StockItemInfo>> Get()
        {
            return await stockService.GetAllAsync();
        }

        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> Get([FromRoute] string id)
        {
            try
            {
                var item = await stockService.GetItemAsync(id);
                return Ok(item);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        [Authorize(Roles = "Administrator")]
        public async Task<StockItemInfo> Add([FromBody] StockItemInfo stockItem)
        {
            var userId = GetCurrentUserId();
            return await stockService.AddItemAsync(userId, stockItem);
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Administrator")]
        public async Task Delete([FromRoute] string id)
        {
            var userId = GetCurrentUserId();
            await stockService.RemoveItem(userId, id);
        }

    }
}
