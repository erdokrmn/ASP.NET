using EShopAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShopAPI.Persistence.BuilderDesign
{
    public class BmwBuilder : ICarBuilder
    {
        public Car Car { get; }

        public BmwBuilder()
            => Car = new Car();

        public void SetBrand()
        {
            Car.Brand = "BMW";
        }

        public void SetGear()
        {
            Car.Gear = "Manuel";
        }

        public void SetKilometer()
        {
            Car.Kilometer = 0;
        }

        public void SetModel()
        {
            Car.Model = "E30";
        }
    }
}
