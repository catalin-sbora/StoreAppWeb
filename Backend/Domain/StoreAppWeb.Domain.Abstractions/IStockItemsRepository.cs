using StoreAppWeb.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreAppWeb.Domain.Abstractions
{
    public interface IStockItemsRepository: IRepository<StockItem>
    {
    }
}
