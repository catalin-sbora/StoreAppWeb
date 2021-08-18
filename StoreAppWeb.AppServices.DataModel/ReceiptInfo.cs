using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreAppWeb.AppServices.DataModel
{
    public class ReceiptInfo
    {
        public string Id { get; set; }
        public List<ReceiptItemInfo> Items { get; set; }
        public decimal Total { get; set; }

    }
}
