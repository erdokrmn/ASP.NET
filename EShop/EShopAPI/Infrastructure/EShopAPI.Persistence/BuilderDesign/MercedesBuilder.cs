using EShopAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShopAPI.Persistence.BuilderDesign
{
    public class MercedesBuilder : ICarBuilder
    {
        public Car Car { get; }
        public MercedesBuilder()
            =>Car= new Car();
        public void SetBrand()
        {
            Car.Brand = "Mercedes";
        }

        public void SetGear()
        {
            Car.Gear = "Auto";
        }

        public void SetKilometer()
        {
            Car.Kilometer = 0;
        }

        public void SetModel()
        {
            Car.Model = "A110";
        }
    }
}
