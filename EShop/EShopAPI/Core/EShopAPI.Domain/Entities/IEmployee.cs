using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public record Memento(string Name, int Age, string Phone,string State);
namespace EShopAPI.Domain.Entities
{
    public interface IEmployee
    {
        public Memento Create();
        void Undo(Memento memento);
    }
}
