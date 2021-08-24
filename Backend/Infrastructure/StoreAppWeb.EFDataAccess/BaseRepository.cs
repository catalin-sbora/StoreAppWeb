using Microsoft.EntityFrameworkCore;
using StoreAppWeb.Domain.Abstractions;
using StoreAppWeb.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreAppWeb.EFDataAccess
{
    public abstract class BaseRepository<T> : IRepository<T> where T: BaseEntity
    {
        protected readonly StoreAppDbContext dbContext;
        public BaseRepository(StoreAppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<T> AddAsync(T newEntity)
        {
            var addedEntity = await dbContext.Set<T>().AddAsync(newEntity);           
            return addedEntity.Entity;
        }

        public virtual async Task<IEnumerable<T>> GetAllAsync()
        {
            var result = await dbContext.Set<T>()
                                        .ToListAsync();
            return result;
        }

        public virtual async Task<T> GetByIdAsync(string id)
        {
            var result = await dbContext.Set<T>()
                                        .FirstOrDefaultAsync(entity => entity.Id.Equals(id));
                                           

            return result;
        }

        public async Task RemoveAsync(string id)
        {

            var toRemove = await dbContext.Set<T>()
                                           .FirstOrDefaultAsync(entity => entity.Id.Equals(id));

            dbContext.Remove(toRemove);
        }

        public abstract Task<T> UpdateAsync(T newInfo);
        
    }
}
