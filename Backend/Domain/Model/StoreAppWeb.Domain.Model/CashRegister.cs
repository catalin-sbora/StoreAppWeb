using StoreAppWeb.Domain.Model.Exceptions;
using System;
using System.Collections.Generic;


namespace StoreAppWeb.Domain.Model
{
    public class CashRegister:BaseEntity
    {
        private List<Receipt> receipts = new List<Receipt>();        
        public Receipt CurrentReceipt { get; private set; }
        public string Name { get; set; }

        public IReadOnlyCollection<Receipt> Receipts => receipts.AsReadOnly();
        
        private CashRegister()
        {
            
        }
        public static CashRegister Create(string identifier, string name=null)
        {
            string crName = name;
            if (string.IsNullOrEmpty(identifier))
            {
                throw new ArgumentNullException("identifier");
            }
            if (string.IsNullOrEmpty(crName))
            {
                crName = $"CR_{identifier}";                
            }            
            var register = new CashRegister() { Id = identifier, Name = crName };
            return register;
        }
        public void StartNewSell()
        {
            if (CurrentReceipt != null)
            {
                throw new SellInProgressException($"A sell is in progress. The current sell must be finalized before starting a new sell", this, CurrentReceipt);
            }
            //CurrentReceipt = new Receipt() { Id = Guid.NewGuid().ToString() };
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
