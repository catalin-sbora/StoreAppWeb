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
        private readonly StoreAppDbContext dbContext;

        public EFPersistenceContext(StoreAppDbContext dbContext)
        {
            this.dbContext = dbContext;
            StoreRepository = new EFStoreRepository(dbContext);
            AdminsRepository = new EFAdminsRepository(dbContext);
            SellersRepository = new EFSellersRepository(dbContext);
        }

        public IAdminsRepository AdminsRepository { get; private set;}

        public ISellersRepository SellersRepository { get; private set; }
        public IStoreRepository StoreRepository { get; private set; }

        public void Initialize(string configOptions)
        {
            throw new NotImplementedException();
        }

        public async Task SaveAsync()
        {
            await dbContext.SaveChangesAsync();
        }
    }
}
