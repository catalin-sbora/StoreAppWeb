using StoreAppWeb.Domain.Model.Exceptions;
using System.Collections.Generic;


namespace StoreAppWeb.Domain.Model
{
    public class CashRegister:BaseEntity
    {
        private List<Receipt> receipts = new List<Receipt>();        
        public Receipt CurrentReceipt { get; private set; }

        public IReadOnlyCollection<Receipt> Receipts => receipts.AsReadOnly();
        
        private CashRegister()
        {
            
        }
        public static CashRegister Create(string identifier)
        {
            var register = new CashRegister() { Id = identifier };
            return register;
        }
        public void StartNewSell()
        {
            if (CurrentReceipt != null)
            {
                throw new SellInProgressException($"A sell is in progress. The current sell must be finalized before starting a new sell", this, CurrentReceipt);
            }
            CurrentReceipt = new Receipt();
        }

        
        public void FinalizeSell()
        {
            if (CurrentReceipt == null)
            {
                throw new NoSellInProgressException($"No sell is in progress to finalize.", this);   
            }
            receipts.Add(CurrentReceipt);
            CurrentReceipt = null;
        }

        public bool IsSellInProgress => (CurrentReceipt != null);



    }
}
