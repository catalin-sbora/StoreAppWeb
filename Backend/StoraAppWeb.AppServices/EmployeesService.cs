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
    public class EmployeesService
    {
        private readonly ISellersRepository sellersRepository;
        private readonly IAdminsRepository adminsRepository;
        private readonly IStoreRepository storeRepository;
        private readonly IPersistenceContext persistenceContext;
        public EmployeesService(IPersistenceContext context)
        {
            persistenceContext = context;
            sellersRepository = context.SellersRepository;
            adminsRepository = context.AdminsRepository;
            storeRepository = context.StoreRepository;
        }

        public async Task<PersonInfo> CreateAdmin(PersonInfo personalData)        
        {                        
            var admin = personalData.ToAdministrator(await storeRepository.GetCurrentStoreAsync());

            await adminsRepository.AddAsync(admin);
            await persistenceContext.SaveAsync();

            return admin.Person.ToInfoObject();
        }

        public async Task<PersonInfo> CreateSeller(PersonInfo personalData)
        {
            var seller = personalData.ToSeller(await storeRepository.GetCurrentStoreAsync());
            await sellersRepository.AddAsync(seller);
            await persistenceContext.SaveAsync();            
            return seller.PersonalData.ToInfoObject();            
        }



        

    }
}
