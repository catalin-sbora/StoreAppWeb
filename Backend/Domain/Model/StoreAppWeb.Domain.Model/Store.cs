using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreAppWeb.Domain.Model
{
    public class Store: BaseEntity
    {
        private List<CashRegister> _cashRegisters = new List<CashRegister>();        
        public string Name { get; set; }
        public Stock Stock { get; private set; }         
        public IReadOnlyCollection<CashRegister> CashRegisters => _cashRegisters.AsReadOnly();
        
        public Store()
        {
            Stock = new Stock();
        }

        private CashRegister GetRegisterById(string id)
        {
            return _cashRegisters
                .SingleOrDefault(register => register.Id.Equals(id)); 
        }
        public void LoadStock(List<StockItem> stockItems)
        {
            foreach (var stockItem in stockItems)
            {
                Stock.Add(stockItem.Product, stockItem.Qty);
            }
        }

        public void LoadDefaultCashRegisters()
        {
            InstallNewCashRegister("1","Default");
        }
        public void InstallNewCashRegister(string identifier, string crName)
        {
            if (string.IsNullOrEmpty(identifier))
            {
                throw new ArgumentException($"Invalid identifier provided for a cash register");
            }
            var existingRegister = GetRegisterById(identifier);
            if (existingRegister != null)
            {
                throw new ArgumentException($"Cash register with the given identifier {identifier} already installed", "identifier");
            }
            _cashRegisters.Add(CashRegister.Create(identifier, crName));
        }

        public CashRegister GetCashRegister(string id)
        {
            var existingRegister = GetRegisterById(id);
            if (existingRegister != null)
            {
                return existingRegister;
            }
            throw new ArgumentException($"Invalid register identifier {id}", "id");
        }

        public void UninstallCashRegister(string id)
        {
            var existingRegister = GetRegisterById(id);
            if (existingRegister == null)
            {
                throw new ArgumentException($"Invalid register identifier {id}", "id");
            }
            _cashRegisters.Remove(existingRegister);
        }

        

    }
}
