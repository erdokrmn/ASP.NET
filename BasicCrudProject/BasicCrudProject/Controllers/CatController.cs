using BasicCrudProject.Models;
using Microsoft.AspNetCore.Mvc;

namespace BasicCrudProject.Controllers
{
    public class CatController : Controller
    {
        public IActionResult Read()
        {
            var cats = new List<Cat>
            {
                new Cat{Id=1,CatName="Ragnar",CatBreed="None"},
                new Cat{Id=2,CatName="Garfield",CatBreed="Van"},
                new Cat{Id=3,CatName="Boncuk",CatBreed="None"}

            };

            return View(cats);
        }
    }
}
