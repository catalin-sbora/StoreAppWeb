using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreAppWeb.AppServices.DataModel
{
    public class ReceiptItemInfo
    {
        public string ProductName { get; set; }
        public int Qty { get; set; }       
        public decimal PricePerUnit{ get; set; }
        public decimal Total { get; set; }
        
    }
}
