using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreAppWeb.Domain.Model
{
    public class Administrator : BaseEntity
    {
        private Store store;
        private int lastCashRegister = 0;

        public Store Store { get => store; private set => store = value; }
        public Person Person { get; set; }

        public Administrator()
        {            
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
        public void ChangeStore(Store newStore)
        {
            Store = newStore;
        }



    }
}
