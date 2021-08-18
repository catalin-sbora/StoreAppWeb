using StoreAppWeb.Domain.Abstractions;
using StoreAppWeb.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreAppWeb.EFDataAccess
{
    public class EFStoreRepository : IStoreRepository
    {
        public Task<Store> GetCurrentStoreAsync()
        {
            throw new NotImplementedException();
        }
    }
}
