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
            var admin = new Administrator();
            admin.ChangeStore(currentStore);
            admin.Person.Id = personInfo.Id;
            admin.Person.FirstName = personInfo.FirstName;
            admin.Person.LastName = personInfo.LastName;
            admin.Person.Email = personInfo.Email;
            return admin;
        }

        public static Seller ToSeller(this PersonInfo personInfo, Store currentStore)
        {  
            var seller = Seller.Create(currentStore, personInfo.ToDomainObject());            
            return seller;
        }
        public static Person ToDomainObject(this PersonInfo personInfo)
        {
            var person = new Person()
            {
                Id = personInfo.Id,
                FirstName = personInfo.FirstName,
                LastName = personInfo.LastName,
                Email = personInfo.Email
            };
            return person;
        }
    }
}
