using StoreAppWeb.Domain.Model.Exceptions;

namespace StoreAppWeb.Domain.Model
{
    public class Seller:BaseEntity
    {
        private readonly Store store;
        private CashRegister currentCashRegister = null;
        private readonly Stock storeStock;
        public Person PersonalData { get; set; }
        public Seller(Store store)
        {
            this.store = store;
            storeStock = store.Stock;
        }

        public void StartSell(string registerId)
        {
            currentCashRegister = store.GetCashRegister(registerId);
            currentCashRegister.StartNewSell();
        }

        public void AddProductToSell(string productId, int qty)
        {
            //validare currentCashRegister
            var item = storeStock.TakeFromStock(productId, qty);
            currentCashRegister.CurrentReceipt
                                .AddProduct(item.Product, qty);
        }

        public Receipt GetCurrentReceipt()
        {
            if (currentCashRegister == null)
            {
                throw new NoCashRegisterSelectedException(this);
            }
            //validare currentCashRegister
            return currentCashRegister.CurrentReceipt;
        }

        public void CloseSell()
        {
            if (currentCashRegister == null)
            {
                throw new NoCashRegisterSelectedException(this);
            }
            currentCashRegister.FinalizeSell();
        }
    }
}
