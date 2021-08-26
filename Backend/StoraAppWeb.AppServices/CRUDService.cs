using StoraAppWeb.AppServices.Converters;
using StoreAppWeb.Domain.Abstractions;
using StoreAppWeb.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoraAppWeb.AppServices
{
    public class CRUDService<InfoClass, DomainClass> where DomainClass : BaseEntity
    {
        protected IPersistenceContext context;
        protected DomainConverter<InfoClass, DomainClass> converter;
        protected IRepository<DomainClass> repository;

        private void GetRepositoryFromContext()
        {
            var properties = context.GetType()
                                    .GetProperties();
            foreach (var property in properties)
            {
                var propertyType = property.GetMethod.ReturnType;
                if (propertyType.IsAssignableTo(typeof(IRepository<DomainClass>)))
                {
                    repository = (IRepository<DomainClass>)property.GetValue(context);
                }
            }
        }
        protected async Task<Administrator> GetAdminAccount(string adminId)
        {
            var adminUser = await context.AdminsRepository.GetByIdAsync(adminId);
            if (adminUser == null)
                throw new ArgumentException("Invalid administrator account");
            return adminUser;
        }
        public CRUDService(IPersistenceContext context, DomainConverter<InfoClass, DomainClass> converter)
        {
            this.context = context;
            this.converter = converter;
            GetRepositoryFromContext();
        }

        public async Task<IEnumerable<InfoClass>> GetAllAsync()
        {
            var domainList = await repository.GetAllAsync();
            return domainList.Select(domainObject => converter.ToInfoObject(domainObject));
        }

        public async Task<InfoClass> GetItemAsync(string itemId)
        {
            var item = await repository.GetByIdAsync(itemId);
            return converter.ToInfoObject(item);
        }

        public async Task<InfoClass> AddItemAsync(string userId, InfoClass item)
        {
            await GetAdminAccount(userId);            
            var newItem = converter.ToDomainObject(item);
            var createdItem = await repository.AddAsync(newItem);
            await context.SaveAsync();
            return converter.ToInfoObject(createdItem);
            
        }

        public async Task RemoveItem(string userId, string itemId)
        {
            await GetAdminAccount(userId);        
            await repository.RemoveAsync(itemId);
            await context.SaveAsync();
        }

       

    }
}
