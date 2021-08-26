using StoreAppWeb.AppServices.DataModel;
using System;
using System.Collections.Generic;
using System.Net.Http;

namespace StoreAppWeb.API.Client
{
    public class StockManagerClient:APIClient<StockItemInfo>
    {        
        public StockManagerClient(HttpClient httpClient):base(httpClient)
        {
            EndpointBase = "/api/stock";
        }        
    }
}
