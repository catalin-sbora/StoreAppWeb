using StoreAppWeb.AppServices.DataModel;
using StoreAppWeb.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoraAppWeb.AppServices.Converters
{
    public class ProductConverter : DomainConverter<ProductInfo, Product>
    {
        public override Product ToDomainObject(ProductInfo info)
        {
            var product = new Product()
            {
                Description = info.Description,
                Id = info.Id,
                Name = info.Name,
                Price = info.Price
            };
            if (string.IsNullOrEmpty(product.Id))
            {
                product.Id = Guid.NewGuid()
                                .ToString();
            }
            return product;
        }

        public override ProductInfo ToInfoObject(Product product)
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
