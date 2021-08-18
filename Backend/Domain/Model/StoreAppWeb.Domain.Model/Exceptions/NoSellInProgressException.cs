using System;


namespace StoreAppWeb.Domain.Model.Exceptions
{
    public class NoSellInProgressException: Exception
    {
        public CashRegister Register { get; private set; }
        public NoSellInProgressException(string message, CashRegister register): base(message)
        {
            Register = register;
        }
    }
}
