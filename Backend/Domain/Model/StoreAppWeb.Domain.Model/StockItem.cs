using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreAppWeb.Domain.Model
{
    public class StockItem:BaseEntity
    {
        public Product Product { get; set; }
        public int Qty 
        { 
            get; 
            set; 
        }

        public decimal Total
        {
            get
            {
                return Product.Price * Qty;
            }
            
        }
    }
}
