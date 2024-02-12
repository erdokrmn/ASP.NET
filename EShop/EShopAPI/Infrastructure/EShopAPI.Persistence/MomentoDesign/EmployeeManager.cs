using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShopAPI.Persistence.MomentoDesign
{
    public class EmployeeManager : IEmployeeManager
    {
        private readonly Stack<Memento> mementos = new Stack<Memento>();

        public void AddMemento(Memento memento) => mementos.Push(memento);
        public Memento GetMemento() => mementos.Pop();
    }
}
