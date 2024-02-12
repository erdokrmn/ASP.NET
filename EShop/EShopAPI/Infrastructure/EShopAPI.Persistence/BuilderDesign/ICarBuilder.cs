using EShopAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShopAPI.Persistence.BuilderDesign
{
    public interface ICarBuilder
    {
        Car Car { get; }
        void SetBrand();
        void SetModel();
        void SetGear();
        void SetKilometer();
    }
}
