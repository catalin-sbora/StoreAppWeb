using StoreAppWeb.Domain.Model.Exceptions;

namespace StoreAppWeb.Domain.Model
{
    public class Seller:BaseEntity
    {
        private Store store;
        private CashRegister currentCashRegister = null;
        private Stock storeStock;
        public Person PersonalData { get; set; }
        public Store Store { get => store; private set => store = value; }
        private Seller()
        {                        
        }
        public static Seller Create(Store store, Person personalData)
        {
            var seller = new Seller();
            seller.Store = store;
            seller.PersonalData = personalData;
            return seller;
        }

        public void StartSell(string registerId)
        {
            currentCashRegister = store.GetCashRegister(registerId);
            currentCashRegister.StartNewSell();
        }

        public void AddProductToSell(string productId, int qty)
        {
            //validare currentCashRegister
            var item = store.Stock.TakeFromStock(productId, qty);
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

        public void ChangeStore(Store newStore)
        {
            Store = newStore;
            storeStock = store.Stock;
        }
    }
}
