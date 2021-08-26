using StoreAppWeb.AppServices.DataModel;
using StoreAppWeb.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoraAppWeb.AppServices.Extensions
{
    public static class ProductInfoExtension
    {
        public static Product ToDomainObject(this ProductInfo info)
        {
            var product = new Product()
            {
                Description = info.Description,
                Id = info.Id,
                Name = info.Name,
                Price = info.Price
            };
            return product;
        }
    }
}
