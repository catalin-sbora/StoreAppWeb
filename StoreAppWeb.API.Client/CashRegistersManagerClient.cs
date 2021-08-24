using StoreAppWeb.API.Client.Extensions;
using StoreAppWeb.AppServices.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace StoreAppWeb.API.Client
{
    public class CashRegistersManagerClient: APIClient<CashRegisterInfo>
    {    
        public CashRegistersManagerClient(HttpClient httpClient):base(httpClient)
        {
            EndpointBase = "/api/cashregisters";            
        }
    }
}
