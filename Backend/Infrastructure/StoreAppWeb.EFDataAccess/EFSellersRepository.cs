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
    public class EFSellersRepository : BaseRepository<Seller>, ISellersRepository
    {
        public EFSellersRepository(StoreAppDbContext dbContext) : base(dbContext)
        { 
        }
        public override async Task<Seller> UpdateAsync(Seller newInfo)
        {
            var currentSeller = await dbContext.Sellers.FirstOrDefaultAsync(admin => admin.Id.Equals(newInfo.Id));
            if (currentSeller == null)
                throw new ArgumentException("Invalid administrator data recevied");
            
            if (newInfo.Store != null)
            {
                currentSeller.ChangeStore(newInfo.Store);
            }
            if (currentSeller.PersonalData != null)
            {
                currentSeller.PersonalData.FirstName = newInfo.PersonalData.FirstName;
                currentSeller.PersonalData.LastName = newInfo.PersonalData.LastName;
                currentSeller.PersonalData.Email = newInfo.PersonalData.Email;
            }

            return currentSeller;
        }
    }
}
