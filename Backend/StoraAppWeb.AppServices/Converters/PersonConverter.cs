using StoreAppWeb.AppServices.DataModel;
using StoreAppWeb.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoraAppWeb.AppServices.Converters
{
    public class PersonConverter : DomainConverter<PersonInfo, Person>
    {
        public override Person ToDomainObject(PersonInfo personInfo)
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

        public override PersonInfo ToInfoObject(Person person)
        {
            var personInfo = new PersonInfo
            {
                Id = person.Id,
                FirstName = person.FirstName,
                LastName = person.LastName,
                Email = person.Email
            };
            return personInfo;
        }
    }
}
