using EShopAPI.Application.Abstractions;
using EShopAPI.Domain.Entities;
using EShopAPI.Persistence.Concretes;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EShopAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
       private  IPersonService personService;


        public PersonController(IPersonService personService)
        {
            this.personService = personService;
        }
        [HttpGet]
        public IActionResult Clone()
        {
            //Protetype pattern için üretildi
            //Infrastrusture klasöründe persistence kısmında concretes klasörünün içinde personservice classında
            //klonlama işlemi yapılıyor.Burada ekrana yazdırılıyor.
            var person = personService.GetPersons();
            

            return Ok(person);
        }
    }
}
