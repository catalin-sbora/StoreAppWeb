using Microsoft.VisualStudio.TestTools.UnitTesting;
using StoreAppWeb.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreAppWeb.Domain.UnitTests
{
    [TestClass]
    public class AdministratorTests
    {
        [TestMethod]
        public void AddNewCashRegister_Adds_CashRegister_To_Store()
        {
            var LastCashRegister = 3;
            var crName = "newCr";

            var store = new Store();
            store.InstallNewCashRegister(LastCashRegister.ToString(), crName);

            var addedCr = store.CashRegisters.Where(cr => cr.Id.Equals(LastCashRegister.ToString())).SingleOrDefault();

            
            Assert.IsNotNull(addedCr, "Cash register was not added to store");
            Assert.IsNotNull(addedCr.Name);
            Assert.AreEqual(LastCashRegister.ToString(), addedCr.Id);
        }

        [TestMethod]
        public void RemoveCashRegister_Removes_Register_From_Store()
        {
            var registerId = "1";
            var store = new Store();

            var existCr = store.CashRegisters.Where(cr => cr.Id.Equals(registerId)).SingleOrDefault();
            store.UninstallCashRegister(registerId);

            var crRemoved = store.CashRegisters.Where(cr => cr.Id.Equals(registerId)).SingleOrDefault();

            Assert.IsNotNull(existCr, "Cash register with id doesn't exist in store");
            Assert.IsNull(crRemoved, "Cash register was not removed from store");
        }

        [TestMethod]
        public void AddNewProductToStock_Adds_Product_To_Stock()
        {
            var product = new Product()
            {
                Id = "1",
                Name = "pr_1",
                Description = "desc_1",
                Price = 23
            };
            var qty = 5;
            var store = new Store();

            store.Stock.Add(product, qty);

            var productAdded = store.Stock.StockItems.Where(s => s.Product.Id.Equals(product.Id)).SingleOrDefault();

            Assert.IsNotNull(product, "Invalid product");
            Assert.IsNotNull(qty, "Quantity is not specified");
            Assert.IsNotNull(productAdded, "Product not added to stock");
        }

        [TestMethod]
        public void RemoveProduct_Removes_Product_From_Stock()
        {
            var productId = "1";
            var admin = new Administrator();

            admin.RemoveProduct(productId);

            var productExist = admin.Store.Stock.StockItems.Where(s => s.Product.Id.Equals(productId)).SingleOrDefault();

            Assert.IsNotNull(productId);
            Assert.IsNull(productExist, "Product not removed from stock");
        }


    }
}
