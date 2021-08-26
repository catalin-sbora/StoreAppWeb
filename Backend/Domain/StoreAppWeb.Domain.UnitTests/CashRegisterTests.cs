using Microsoft.VisualStudio.TestTools.UnitTesting;
using StoreAppWeb.Domain.Model;
using StoreAppWeb.Domain.Model.Exceptions;
using System;
using System.Linq;

namespace StoreAppWeb.Domain.UnitTests
{
    [TestClass]
    public class CashRegisterTests
    {
        [TestMethod]
        public void CreateWithIdAndName_Returns_NewCashRegisterWithGivenIdAndName()
        {
            //Arrange
            var id = "10";
            var name = "CR_Name";

            //Act
            var cr = CashRegister.Create(id, name);

            //Assert
            Assert.IsNotNull(cr);
            Assert.AreEqual(id, cr.Id);
            Assert.AreEqual(name, cr.Name);
        }

        [TestMethod]
        public void CreateWithId_Returns_NewCashRegisterWithIdAndName()
        {
            //Arrange
            var id = "10";      

            //Act
            var cr = CashRegister.Create(id);

            //Assert
            Assert.IsNotNull(cr);
            Assert.AreEqual(id, cr.Id);            
            Assert.IsNotNull(cr.Name);
            Assert.AreNotEqual("", cr.Name);

        }

        [TestMethod]
        public void CreateWithNullId_Throws_ArgumentNullException()
        {
            string id = null;
            Assert.ThrowsException<ArgumentNullException>(() => CashRegister.Create(id));
        }

        [TestMethod]
        public void StartNewSell_Throws_SellInProgressException_If_CurrentReceipt_NotNull()
        {
            //Arrange
            var id = "10";
            var cr = CashRegister.Create(id);
            cr.StartNewSell();
            //Act assert
            Assert.ThrowsException<SellInProgressException>(() => cr.StartNewSell());
        }

        [TestMethod]
        public void StartNewSell_Creates_NewCurrentReceipt()
        {
            var id = "10";
            var cr = CashRegister.Create(id);
            cr.StartNewSell();
            Assert.IsNotNull(cr.CurrentReceipt);
        }

        [TestMethod]
        public void FinalizeSell_Throws_NoSellInProgressException_If_CurrentReceipt_Null()
        {
            var id = "10";
            var cr = CashRegister.Create(id);            
            Assert.ThrowsException<NoSellInProgressException>(()=>cr.FinalizeSell());
        }

        [TestMethod]
        public void FinalizeSell_Adds_Receipt_To_Receipts()
        {
            var id = "10";
            var cr = CashRegister.Create(id);
            cr.StartNewSell();
            var receipt = cr.CurrentReceipt;

            //Act
            cr.FinalizeSell();

            var addedReceipt = cr.Receipts.Where(r => r.Id.Equals(receipt.Id))
                                          .SingleOrDefault();

            Assert.IsNotNull(addedReceipt,"Current receipt was not added to receipts list.");
        }

        [TestMethod]
        public void FinalizeSell_Invalidate_CurrentReceipt()
        {
            var id = "10";
            var cr = CashRegister.Create(id);
            cr.StartNewSell();
            var receipt = cr.CurrentReceipt;

            //Act
            cr.FinalizeSell();

            Assert.IsNull(cr.CurrentReceipt,"Current receipt was not invalidated during FinalizeSell");
        }


    }
}
