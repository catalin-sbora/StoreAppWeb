using StoreAppWeb.AppServices.DataModel;
using StoreAppWeb.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoraAppWeb.AppServices.Extensions
{
    public static class PersonExtension
    {
        public static PersonInfo ToPersonInfo(this Person person)
        {
            var personInfo = new PersonInfo {
                Id = person.Id,
                FirstName = person.FirstName,
                LastName = person.LastName,
                Email = person.Email
            };
            return personInfo;
        }
    }
}
