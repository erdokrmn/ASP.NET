using EShopAPI.Application.Abstractions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EShopAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private IEmployeeService employeeService;


        public EmployeeController(IEmployeeService employeeService)
        {
            this.employeeService = employeeService;
        }
        [HttpGet]
        public IActionResult GetEmployee()
        {
            //Protetype pattern için üretildi
            //Infrastrusture klasöründe persistence kısmında concretes klasörünün içinde personservice classında
            //klonlama işlemi yapılıyor.Burada ekrana yazdırılıyor.
            var employees = employeeService.GetEmployee();


            return Ok(employees);
        }
    }
}
