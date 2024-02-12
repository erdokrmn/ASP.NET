using EShopAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShopAPI.Persistence.PrototypeDesign
{
    public interface ICloneable
    {
        public object Clone();
    }
}
