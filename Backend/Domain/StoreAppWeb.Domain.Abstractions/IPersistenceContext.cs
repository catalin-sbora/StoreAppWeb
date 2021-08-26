using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreAppWeb.Domain.Abstractions
{
    public interface IPersistenceContext
    {
        void Initialize(string configOptions);
        IAdminsRepository AdminsRepository { get; }
        ISellersRepository SellersRepository { get; }        
        IStoreRepository StoreRepository { get; }
        IStockItemsRepository StockItemsRepository { get; }
        Task SaveAsync();
    }
}
