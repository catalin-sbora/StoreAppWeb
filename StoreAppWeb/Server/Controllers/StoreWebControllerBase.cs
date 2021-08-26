using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StoraAppWeb.AppServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace StoreAppWeb.Server.Controllers
{    
    public class StoreWebControllerBase: ControllerBase
    {
        protected string GetCurrentUserId()
        {
            var userId = User.Claims
                        .FirstOrDefault(c => c.Type.Equals(ClaimTypes.NameIdentifier))
                        .Value;
            return userId;
        }
    }
}
