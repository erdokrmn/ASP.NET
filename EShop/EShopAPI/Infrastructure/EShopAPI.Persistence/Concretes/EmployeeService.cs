using EShopAPI.Application.Abstractions;
using EShopAPI.Domain.Entities;
using EShopAPI.Persistence.MomentoDesign;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShopAPI.Persistence.Concretes
{
    public class EmployeeService : IEmployeeService
    {
        public List<Employee> GetEmployee()
        {
            List<Employee> employees = new();
            //durum 1
            var employee = new Employee { Name = "Ahmet", Age = 24, Phone = "123" ,State="1"};
            var employeeManager = new EmployeeManager();
            employeeManager.AddMemento(employee.Create());


            //durum 2
            employee.Age= 25;
            employeeManager.AddMemento(employee.Create());

            //durum 3
            employee.Age = 26;
            employeeManager.AddMemento(employee.Create());

            //tekrar durum 1'e dönme
            employee.Undo(employeeManager.GetMemento());
            employee.Undo(employeeManager.GetMemento());
            employee.Undo(employeeManager.GetMemento());
            employees.Add(employee);

            return employees;

        }

    }
}
