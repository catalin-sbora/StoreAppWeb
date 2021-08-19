using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StoraAppWeb.AppServices;
using StoreAppWeb.AppServices.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace StoreAppWeb.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize(Roles = "Administrator")]
    public class CashRegistersController : ControllerBase
    {

        private readonly CashRegistersService registersService;

        private string GetCurrentUserId()
        {
            var userId = User.Claims
                        .FirstOrDefault(c => c.Type.Equals(ClaimTypes.NameIdentifier))
                        .Value;
            return userId;
        }
        public CashRegistersController(CashRegistersService registersService)
        {
            this.registersService = registersService;
        }

        [HttpGet]
        public async Task<IEnumerable<CashRegisterInfo>> Get()
        {
            return await registersService.GetAll();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get([FromRoute] string id)
        {
            try
            {
               var cashRegiser =  await registersService.GetCashRegister(id);
                return Ok(cashRegiser);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        public async Task<CashRegisterInfo> Add()
        {
            var userId = GetCurrentUserId();            
            return await registersService.AddCashRegister(userId);
        }

        [HttpDelete("{id}")]
        public async Task Delete([FromRoute]string id)
        {
            var userId = GetCurrentUserId();
            await registersService.RemoveCashRegister(userId, id);
        }

    }
}
