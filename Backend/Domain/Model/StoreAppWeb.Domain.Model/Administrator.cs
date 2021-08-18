using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreAppWeb.Domain.Model
{
    public class Administrator : BaseEntity
    {
        
        private int lastCashRegister = 0;

        public Store Store { get; }
        public Person Person { get; }

        public Administrator(Store store)
        {
            Store = store;
        }
        public CashRegister AddNewCashRegister()
        {
            lastCashRegister++;
            Store.InstallNewCashRegister(lastCashRegister.ToString());
            return Store.GetCashRegister(lastCashRegister.ToString());
        }

        public void RemoveCashRegister(string registerId)
        {
            Store.UninstallCashRegister(registerId);

        }
        public void AddNewProductToStock(Product product, int qty)
        {
            Store.Stock.Add(product, qty);
        }

        public void RemoveProduct(string productId)
        {          
            Store.Stock.Remove(productId);           
        }



    }
}
