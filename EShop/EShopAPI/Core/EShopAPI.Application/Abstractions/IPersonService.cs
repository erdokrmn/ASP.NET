using EShopAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShopAPI.Application.Abstractions
{
    public interface IPersonService 
    {
        //Protetype pattern için üretildi
         List<Person> GetPersons();
    }
}
