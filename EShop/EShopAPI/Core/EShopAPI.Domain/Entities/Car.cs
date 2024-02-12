using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShopAPI.Domain.Entities
{
    public class Car
    {
        public string Brand { get; set; }
        public string Model { get; set; }
        public string Gear { get; set; }
        public int Kilometer { get; set; }
    }
}
