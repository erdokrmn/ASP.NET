using EShopAPI.API.Aspects;
using EShopAPI.Application.Abstractions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EShopAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarController : ControllerBase
    {
         private ICarService carService;

        
        public CarController(ICarService carService)
        {
            this.carService = carService;
        }
        [HttpGet]
        [DurationLogging]
        public IActionResult GetCar()
        {
            //
            var car = carService.GetCar();


            return Ok(car);
        }

    }
}
