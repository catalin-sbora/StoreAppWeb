using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreAppWeb.AppServices.DataModel
{
    public class StockItemInfo
    {
        public string Id { get; set; }
        public ProductInfo Product { get; set; }
        public int Qty { get; set; }
        public decimal TotalValue { get; set; }
    }
}
