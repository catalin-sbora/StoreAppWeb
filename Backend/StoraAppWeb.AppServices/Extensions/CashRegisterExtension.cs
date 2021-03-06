using StoreAppWeb.AppServices.DataModel;
using StoreAppWeb.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoraAppWeb.AppServices.Extensions
{
    public static class CashRegisterExtension
    {
        public static CashRegisterInfo ToInfoObject(this CashRegister cashRegister)
        {
            var crInfo = new CashRegisterInfo {
                Id = cashRegister.Id,
                Name = cashRegister.Name,
                CurrentReceipt = null//cashRegister.CurrentReceipt?.ToReceiptInfo(),                
            };

            crInfo.Receipts = new List<ReceiptInfo>();

            return crInfo;
        }
    }
}
