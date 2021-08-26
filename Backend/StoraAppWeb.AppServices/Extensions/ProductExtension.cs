using StoreAppWeb.AppServices.DataModel;
using StoreAppWeb.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoraAppWeb.AppServices.Extensions
{
    public static class ProductExtension
    {
        public static ProductInfo ToInfoObject(this Product product)
        {
            return new ProductInfo
            {
                Id = product.Id,
                Description = product.Description,
                Name = product.Name,
                Price = product.Price
            };
        }
    }
}
