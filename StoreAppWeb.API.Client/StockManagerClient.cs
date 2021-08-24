using StoreAppWeb.AppServices.DataModel;
using System;
using System.Collections.Generic;
using System.Net.Http;

namespace StoreAppWeb.API.Client
{
    public class StockManagerClient
    {
        private HttpClient httpClient;
        public StockManagerClient(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }
        public List<StockItemInfo> GetStockItems()
        {
            return new List<StockItemInfo>();
        }
    }
}
