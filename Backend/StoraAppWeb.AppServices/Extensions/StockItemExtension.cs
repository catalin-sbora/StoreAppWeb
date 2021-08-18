using StoreAppWeb.AppServices.DataModel;
using StoreAppWeb.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoraAppWeb.AppServices.Extensions
{
    public static class StockItemExtension
    {
        public static StockItemInfo ToStockItemInfo(this StockItem stockItem)
        {
            var stockItemInfo = new StockItemInfo
            {
                Id = stockItem.Id,
                Product = stockItem.Product
                                   .ToProductInfo(),
                Qty = stockItem.Qty,                
                TotalValue = stockItem.Total
            };

            return stockItemInfo;
        }
    }
}
