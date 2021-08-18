using System;

namespace StoreAppWeb.Domain.Model.Exceptions
{
    public class NoCashRegisterSelectedException: Exception
    {
        public Seller CurrentSeller { get; private set; }
        public NoCashRegisterSelectedException(Seller currentSeller): base($"No cash register selected.")
        {
            CurrentSeller = currentSeller;
        }

    }
}
