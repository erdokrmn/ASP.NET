using EShopAPI.Application.Abstractions;
using EShopAPI.Domain.Entities;
using EShopAPI.Persistence.Concretes;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShopAPI.Persistence
{
    public static class ServiceRegistration
    {
        public static void AddPersistenceServices(this IServiceCollection services)
        {
            services.AddSingleton<IPersonService, PersonService>();
            services.AddSingleton<ICarService, CarService>();
            services.AddSingleton<IEmployeeService, EmployeeService>();
            //services.AddSingleton<ICarService, MercedesBuilderSevice>();
            //services.AddSingleton<ICarService, OpelBuilderService>();
        }
        
    }
}
