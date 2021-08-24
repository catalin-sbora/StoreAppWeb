using Microsoft.EntityFrameworkCore;
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
        private readonly StoreAppDbContext dbContext;
        public EFStoreRepository(StoreAppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<Store> GetCurrentStoreAsync()
        {
            return await dbContext.Stores
                                  .Include(s=>s.CashRegisters)
                                  .FirstOrDefaultAsync();
        }
    }
}
