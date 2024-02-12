using EShopAPI.Application.Abstractions;
using EShopAPI.Domain.Entities;
using EShopAPI.Persistence.Aspects;
using EShopAPI.Persistence.BuilderDesign;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace EShopAPI.Persistence.Concretes
{
    [DurationLogging]
    public class CarService : ICarService
    {
        
        public List<Car> GetCar()
        {
            CarDirector carDirector=new();

            Car Mercedes=carDirector.Build(new MercedesBuilder());

            Car BMW = carDirector.Build(new BmwBuilder());

            List<Car> carList= new List<Car>();
            carList.Add(Mercedes);
            carList.Add(BMW);

            return carList;
        }
    }
}
