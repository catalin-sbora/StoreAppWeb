using Microsoft.VisualStudio.TestTools.UnitTesting;
using StoreAppWeb.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace StoreAppWeb.Domain.UnitTests
{
    [TestClass]
    public class StoreTests
    {
        [TestMethod]
        public void LoadStock_FillsStock_WithGivenItems()
        {
            //Arrange
            Store store = new Store();
            int numItems = 3;
            List<StockItem> stockItems = new List<StockItem>();
            for (int i = 0; i < numItems; i++)
            {
                Product mockProduct = new Product() { Id = i.ToString(), Name = $"P{i}" };
                stockItems.Add(new StockItem() { Product = mockProduct });
            }

            //Act
            store.LoadStock(stockItems);

            //Assert
            Assert.AreEqual(store.Stock.StockItems.Count, numItems);
            for (int i = 0; i < numItems; i++)
            {
                var item = store.Stock.StockItems.ElementAt(i);
                Assert.AreEqual(item.Product.Id, i.ToString());
            }
        }

        [TestMethod]
        public void InstallNewCashRegister_Throws_ArgumentException_If_Identifier_NullOrEmpty()
        { 
            // Arrange
            Store store = new Store();
            string identifier1 = null;
            string identifier2 = "";
            string crName = "testCrName";

            // Act + Assert
            Assert.ThrowsException<ArgumentException>(() => store.InstallNewCashRegister(identifier1, crName));
            Assert.ThrowsException<ArgumentException>(() => store.InstallNewCashRegister(identifier2, crName));
        }

        [TestMethod]
        public void InstallNewCashRegister_Throws_ArgumentException_If_GivenRegister_AlreadyInstalled()
        {
            // Arrange
            Store store = new Store();
            string identifier = "testIdentifier";
            string crName = "testCrName";

            //Act
            store.InstallNewCashRegister(identifier, crName);

            //Assert
            Assert.ThrowsException<ArgumentException>(() => store.InstallNewCashRegister(identifier, crName));
        }

        [TestMethod]
        public void InstallNewCashRegister_AddsToCashRegisters_GivenRegister()
        {
            //Arrange
            Store store = new Store();
            string identifier = "testIdentifier";
            string crName = "testCrName";

            //Act
            store.InstallNewCashRegister(identifier, crName);
            CashRegister addedRegister = store.CashRegisters.LastOrDefault();

            //Assert
            Assert.AreEqual(addedRegister.Id, identifier);
            Assert.AreEqual(addedRegister.Name, crName);
        }

        [TestMethod]
        public void LoadDefaultCashRegisters_WhenCalled_AddsDefaultRegister_WithId1AndNameDefault()
        {
            //Arrange
            Store store = new Store();
            string defaultId = "1";
            string defaultName = "Default";

            //Act
            store.LoadDefaultCashRegisters();
            CashRegister register = store.CashRegisters.FirstOrDefault();

            //Assert
            Assert.AreEqual(register.Id, defaultId);
            Assert.AreEqual(register.Name, defaultName);
        } 
    }
}
