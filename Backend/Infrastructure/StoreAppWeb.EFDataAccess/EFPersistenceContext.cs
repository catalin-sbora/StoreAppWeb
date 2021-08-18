using StoreAppWeb.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreAppWeb.EFDataAccess
{
    public class EFPersistenceContext : IPersistenceContext
    {
        public IAdminsRepository AdminsRepository => throw new NotImplementedException();

        public ISellersRepository SellersRepository => throw new NotImplementedException();

        public IStoreRepository CashRegistersRepository => throw new NotImplementedException();

        public IStoreRepository StoreRepository => throw new NotImplementedException();

        public void Initialize(string configOptions)
        {
            throw new NotImplementedException();
        }

        public Task SaveAsync()
        {
            throw new NotImplementedException();
        }
    }
}
