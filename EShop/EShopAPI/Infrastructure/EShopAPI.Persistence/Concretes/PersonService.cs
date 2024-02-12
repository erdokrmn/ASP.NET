using EShopAPI.Application.Abstractions;
using EShopAPI.Domain.Entities;
using EShopAPI.Persistence.PrototypeDesign;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShopAPI.Persistence.Concretes
{
    public class PersonService : IPersonService
    {


        public List<Person> GetPersons()
        {
            Person person = new("Hasan", "Karaman", "Student");
            Person person2 = (Person)person.Clone();
            person2.Name = "Ali";
            Person person3 = (Person)person2.Clone();
            
            person3.Surname = "Çağlayan";
            List<Person> persons=new();
            persons.Add(person2);
            persons.Add(person3);
            return persons;
        }
    }
}
