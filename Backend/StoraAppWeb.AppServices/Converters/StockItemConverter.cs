using StoreAppWeb.AppServices.DataModel;
using StoreAppWeb.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoraAppWeb.AppServices.Converters
{
    public class StockItemConverter : DomainConverter<StockItemInfo, StockItem>
    {
       private ProductConverter productConverter = new ProductConverter();
        public override StockItem ToDomainObject(StockItemInfo infoObject)
        {
            var stock = new StockItem()
            {
                Id = infoObject.Id,
                Product = productConverter.ToDomainObject(infoObject.Product),
                Qty = infoObject.Qty
            };

            return stock;
        }

        public override StockItemInfo ToInfoObject(StockItem stockItem)
        {
            
            var stockItemInfo = new StockItemInfo
            {
                Id = stockItem.Id,
                Product = productConverter.ToInfoObject(stockItem.Product),
                Qty = stockItem.Qty,
                TotalValue = stockItem.Total
            };

            return stockItemInfo;
        }
    }
}
