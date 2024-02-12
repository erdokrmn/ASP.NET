using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace EShopAPI.Domain.Entities
{
    public class Person : ICloneable
    {
        public Person(string name,string surname,string title)
        {
            Name = name;
            Surname = surname;
            Title = title;
            
        }

        public string? Name { get; set; }
        public string? Surname { get; set; }
        public string? Title { get; set; }

        public object Clone()
        {
            return base.MemberwiseClone();
        }
    }
}
