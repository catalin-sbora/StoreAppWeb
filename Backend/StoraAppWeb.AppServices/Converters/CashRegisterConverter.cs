using StoreAppWeb.AppServices.DataModel;
using StoreAppWeb.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoraAppWeb.AppServices.Converters
{
    public class CashRegisterConverter : DomainConverter<CashRegisterInfo, CashRegister>
    {
        public override CashRegister ToDomainObject(CashRegisterInfo infoObject)
        {
            return CashRegister.Create(infoObject.Id, infoObject.Name);
        }

        public override CashRegisterInfo ToInfoObject(CashRegister cashRegister)
        {
            var crInfo = new CashRegisterInfo
            {
                Id = cashRegister.Id,
                Name = cashRegister.Name,
                CurrentReceipt = null//cashRegister.CurrentReceipt?.ToReceiptInfo(),                
            };

            crInfo.Receipts = new List<ReceiptInfo>();

            return crInfo;
        }
    }
}
