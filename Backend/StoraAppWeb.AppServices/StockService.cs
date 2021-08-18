using StoraAppWeb.AppServices.Extensions;
using StoreAppWeb.AppServices.DataModel;
using StoreAppWeb.Domain.Abstractions;
using StoreAppWeb.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoraAppWeb.AppServices
{
    public class StockService
    {
        private readonly IPersistenceContext context;
        public StockService(IPersistenceContext context)
        {
            this.context = context;
        }
        private async Task<Administrator> GetAdminAccount(string adminId)
        {
            var adminUser = await context.AdminsRepository.GetByIdAsync(adminId);
            if (adminUser == null)
                throw new ArgumentException("Invalid administrator account");
            return adminUser;
        }

        public async Task<IEnumerable<StockItemInfo>> GetStockItems()   
        {
            var store = await context.StoreRepository
                                     .GetCurrentStoreAsync();

            var stockItems = store.Stock
                                  .StockItems
                                  .Select(stockItem => stockItem.ToStockItemInfo());

            return stockItems.AsEnumerable();
            
        }
        public async Task<ProductInfo> AddProduct(string adminId, ProductInfo product, int qty)
        {
            var admin = await GetAdminAccount(adminId);
            var stock = admin.Store.Stock;
            var newProduct = product.ToProduct();
            stock.Add(newProduct, qty);
            await context.SaveAsync();
            return newProduct.ToProductInfo();
        }

        public async Task RemoveProduct(string adminId, string productId)
        {
            var admin = await GetAdminAccount(adminId);
            admin.RemoveProduct(productId);
        }

        public async Task<StockItemInfo> TakeProductFromStock(string productId, int qty)
        {
            var store = await context.StoreRepository
                                     .GetCurrentStoreAsync();

            var item = store.Stock.TakeFromStock(productId, qty);
            await context.SaveAsync();
            return item.ToStockItemInfo();
        }



    }
}
