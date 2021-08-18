using StoreAppWeb.AppServices.DataModel;
using StoreAppWeb.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoraAppWeb.AppServices.Extensions
{
    public static class PersonInfoExtension
    {
        

        public static Administrator ToAdministrator(this PersonInfo personInfo, Store currentStore)
        {
            var admin = new Administrator(currentStore);
            admin.Person.Id = personInfo.Id;
            admin.Person.FirstName = personInfo.FirstName;
            admin.Person.LastName = personInfo.LastName;
            admin.Person.Email = personInfo.Email;
            return admin;
        }

        public static Seller ToSeller(this PersonInfo personInfo, Store currentStore)
        {  
            var seller = new Seller(currentStore);
            seller.PersonalData.Id = personInfo.Id;
            seller.PersonalData.FirstName = personInfo.FirstName;
            seller.PersonalData.LastName = personInfo.LastName;
            seller.PersonalData.Email = personInfo.Email;
            return seller;
        }
    }
}
