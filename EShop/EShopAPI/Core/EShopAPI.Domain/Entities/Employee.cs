using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace EShopAPI.Domain.Entities
{
    public class Employee :IEmployee
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string Phone { get; set; }
        public string State { get; set; }

        public Memento Create() => new Memento(Name, Age, Phone,State);
        public void Undo(Memento memento)
        {
            Name = memento.Name;
            Age = memento.Age;
            Phone = memento.Phone;
            State = memento.State;
        }
    }
}
