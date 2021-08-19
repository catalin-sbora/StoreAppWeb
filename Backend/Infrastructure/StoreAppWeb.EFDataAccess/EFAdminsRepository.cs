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
    public class EFAdminsRepository : BaseRepository<Administrator>, IAdminsRepository
    {
        public EFAdminsRepository(StoreAppDbContext dbContext) : base(dbContext)
        { 
        }
        public override async Task<Administrator> UpdateAsync(Administrator newInfo)
        {
            var currentAdmin = await dbContext.Administrators.FirstOrDefaultAsync(admin => admin.Id.Equals(newInfo.Id));
            if (currentAdmin == null)
                throw new ArgumentException("Invalid administrator data recevied");
            //currentAdmin.
            if (newInfo.Store != null)
            { 
                currentAdmin.Store.Name = newInfo.Store.Name;
            }
            if (currentAdmin.Person != null)
            {
                currentAdmin.Person.FirstName = newInfo.Person.FirstName;
                currentAdmin.Person.LastName = newInfo.Person.LastName;
                currentAdmin.Person.Email = newInfo.Person.Email;
            }

            return currentAdmin;

        }
    }
}
