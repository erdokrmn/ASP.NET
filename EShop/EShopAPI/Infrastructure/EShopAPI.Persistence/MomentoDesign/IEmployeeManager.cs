using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShopAPI.Persistence.MomentoDesign
{
    public interface IEmployeeManager
    {
        void AddMemento(Memento memento);
        Memento GetMemento();
        
    }
}
