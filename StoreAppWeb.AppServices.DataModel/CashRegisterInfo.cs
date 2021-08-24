using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreAppWeb.AppServices.DataModel
{
    public class CashRegisterInfo
    {
        public string Id { get; set; }        
        [Required]
        public string Name { get; set; }
        public List<ReceiptInfo> Receipts { get; set; }
        public ReceiptInfo CurrentReceipt { get; set; }       
    }
}
