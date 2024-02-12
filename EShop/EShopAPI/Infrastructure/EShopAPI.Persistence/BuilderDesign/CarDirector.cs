using EShopAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShopAPI.Persistence.BuilderDesign
{
    public class CarDirector
    {
        public Car Build(ICarBuilder carBuilder)
        {
            carBuilder.SetGear();
            carBuilder.SetBrand();
            carBuilder.SetKilometer();
            carBuilder.SetModel();
            return carBuilder.Car;

        }
    }
}
