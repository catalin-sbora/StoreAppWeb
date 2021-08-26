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
    public class EFStockItemsRepository : BaseRepository<StockItem>, IStockItemsRepository
    {
        public EFStockItemsRepository(StoreAppDbContext context) : base(context)
        {
            
        }

        public async override Task<StockItem> GetByIdAsync(string id)
        {
            return await dbContext.StockItems
                           .Include(item => item.Product)                           
                           .Where(item => item.Id.Equals(id))
                           .SingleOrDefaultAsync();
        }

        public async override Task<IEnumerable<StockItem>> GetAllAsync()
        {
            return await dbContext.StockItems
                           .Include(item => item.Product)
                           .ToListAsync();
        }

        public async override Task<StockItem> UpdateAsync(StockItem newInfo)
        {
            var item =  await dbContext.StockItems.Where(item => item.Id.Equals(newInfo))
                                            .FirstOrDefaultAsync();

            if (item != null)
            {
                item.Product = newInfo.Product;
                item.Qty = newInfo.Qty;                
            }
            return item;
        }
    }
}
