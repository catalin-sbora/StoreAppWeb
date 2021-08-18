using System;

namespace StoreAppWeb.Domain.Model.Exceptions
{
    public class SellInProgressException: Exception
    {
        public CashRegister Register { get; private set; }
        public Receipt SellReceipt { get; private set; }

        public SellInProgressException(string message, CashRegister register, Receipt sellReceipt) : base(message)
        {
            Register = register;
            SellReceipt = sellReceipt;
        }
    }
}
