using StoraAppWeb.AppServices.Extensions;
using StoreAppWeb.AppServices.DataModel;
using StoreAppWeb.Domain.Abstractions;
using StoreAppWeb.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoraAppWeb.AppServices
{
    public class CashRegistersService
    {
        private readonly IPersistenceContext context;
        
        public CashRegistersService(IPersistenceContext context)
        {
            this.context = context;            
        }

        private async Task<Administrator> GetAdminAccount(string adminId)
        {
            var adminUser = await context.AdminsRepository.GetByIdAsync(adminId);
            if (adminUser == null)
                throw new ArgumentException("Invalid administrator account");
            return adminUser;
        }

        public async Task<IEnumerable<CashRegisterInfo>> GetAll()
        {
            var store = await context.StoreRepository.GetCurrentStoreAsync();
            IEnumerable<CashRegisterInfo> registers = new List<CashRegisterInfo>();
            if (store != null)
            {
                 registers= store.CashRegisters
                                     .Select(register => register.ToCashRegisterInfo());
            }
            return registers;
        }

        public async Task<CashRegisterInfo> GetCashRegister(string id)
        {
            var store = await context.StoreRepository.GetCurrentStoreAsync();
            CashRegister register = null;
            if (store != null)
            {
                register = store.CashRegisters
                                     .Where(register => register.Id.Equals(id))
                                     .SingleOrDefault();
            }
            if (register == null)
                throw new ArgumentException($"Invalid register id {id}");

            return register.ToCashRegisterInfo();
        }

        public async Task<CashRegisterInfo> AddCashRegister(string adminId)
        {
            var adminUser = await GetAdminAccount(adminId);
            var addedRegister = adminUser.AddNewCashRegister();
            await context.SaveAsync();
            return addedRegister.ToCashRegisterInfo();   
        }

        public async Task RemoveCashRegister(string adminId, string cashRegisterId)
        {
            var adminUser = await GetAdminAccount(adminId);
            adminUser.RemoveCashRegister(cashRegisterId);
            await context.SaveAsync();
        }


    }
}
