using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StoreAppWeb.Domain.Model;
using StoreAppWeb.Domain.Model.Exceptions;

namespace StoreAppWeb.Domain.UnitTests
{
    [TestClass]
    public class SellerTests
    {
        [TestMethod]
        public void CreateSeller_Returns_SellerWithGivenStoreAndPersonalData()
        {
            //Arrange
            var store = new Store();
            var personalData = new Person()
            {
                FirstName = "firstName",
                Email = "email@email.com",
                Id = "Id",
                LastName = "LastName"
            };

            //Act
            var seller = Seller.Create(store, personalData);

            //Assert
            Assert.IsNotNull(seller);
            Assert.AreEqual(personalData, seller.PersonalData);
            Assert.AreEqual(store, seller.Store);
        }

        [TestMethod]
        public void AddProductToSell_TakesItemsFromStockAndAddsThemToReceipt()
        {
            //Arrange
            var store = new Store();
            var crId = "1";
            var cr = CashRegister.Create(crId);
            var product = new Product()
            {
                Description = "description",
                Id = "id",
                Name = "name",
                Price = 100
            };
            var personalData = new Person()
            {
                FirstName = "firstName",
                Email = "email@email.com",
                Id = "Id",
                LastName = "LastName"
            };
            store.Stock.Add(product, 10);
            store.InstallNewCashRegister(cr.Id, cr.Name);
            var seller = Seller.Create(store, personalData);

            seller.StartSell(crId);

            //Act
            seller.AddProductToSell("id", 2);

            var stockItems = seller.Store.Stock.StockItems;
            var stockItem = stockItems.SingleOrDefault(x => x.Id.Equals(product.Id));

            var receiptItems = store.GetCashRegister(crId).CurrentReceipt.Items;

            var itemOnCurrentReceipt = receiptItems.FirstOrDefault(x => x.Id.Equals(product.Id));

            //Asserts
            Assert.IsNotNull(stockItem);

            Assert.IsNotNull(itemOnCurrentReceipt);

            Assert.AreEqual(8, stockItem.Qty);

        }

        [TestMethod]
        public void GetCurrentReceipt_Throws_NoCashRegisterSelectedException_IfCurrentCashRegisterEqualsNull()
        {
            var store = new Store();
            var personalData = new Person()
            {
                FirstName = "firstName",
                Email = "email@email.com",
                Id = "Id",
                LastName = "LastName"
            };
            var seller = Seller.Create(store, personalData);

            Assert.ThrowsException<NoCashRegisterSelectedException>(() => seller.GetCurrentReceipt());
        }

        [TestMethod]
        public void GetCurrentReceipt_Returns_CurrentReceiptFromCashRegister()
        {
            //Arrange
            var store = new Store();
            var crId = "1";
            var cr = CashRegister.Create(crId);
            var product = new Product()
            {
                Description = "description",
                Id = "id",
                Name = "name",
                Price = 100
            };
            var personalData = new Person()
            {
                FirstName = "firstName",
                Email = "email@email.com",
                Id = "Id",
                LastName = "LastName"
            };
            store.Stock.Add(product, 10);
            store.InstallNewCashRegister(cr.Id, cr.Name);
            var seller = Seller.Create(store, personalData);

            seller.StartSell(crId);
            seller.AddProductToSell("id", 2);

            //Act
            var currentReceipt = seller.GetCurrentReceipt();

            //Assert
            Assert.IsNotNull(currentReceipt);
            Assert.AreEqual(1, currentReceipt.Items.Count);
        }

        [TestMethod]
        public void CloseSell_Throws_NoCashRegisterSelectedException_IfCurrentCashRegisterEqualsNull()
        {
            var store = new Store();
            var personalData = new Person()
            {
                FirstName = "firstName",
                Email = "email@email.com",
                Id = "Id",
                LastName = "LastName"
            };
            var seller = Seller.Create(store, personalData);

            //act/assert

            Assert.ThrowsException<NoCashRegisterSelectedException>(() => seller.CloseSell());
        }

        [TestMethod]
        public void CloseSell_Make_CurrentReceiptNull()
        {
            //Arrange
            var store = new Store();
            var crId = "1";
            var cr = CashRegister.Create(crId);
            var product = new Product()
            {
                Description = "description",
                Id = "id",
                Name = "name",
                Price = 100
            };
            var personalData = new Person()
            {
                FirstName = "firstName",
                Email = "email@email.com",
                Id = "Id",
                LastName = "LastName"
            };
            store.Stock.Add(product, 10);
            store.InstallNewCashRegister(cr.Id, cr.Name);
            var seller = Seller.Create(store, personalData);

            seller.StartSell(crId);
            seller.AddProductToSell("id", 2);

            //Act
            seller.CloseSell();

            //Assert
            Assert.IsNull(seller.GetCurrentReceipt());
        }
    }
}
