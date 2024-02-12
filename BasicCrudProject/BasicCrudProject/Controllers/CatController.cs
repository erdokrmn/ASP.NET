using BasicCrudProject.Data;
using BasicCrudProject.Models;
using Microsoft.AspNetCore.Mvc;

namespace BasicCrudProject.Controllers
{
    public class CatController : Controller
    {
        
        public IActionResult Read()
        {

            return View();
        }
    }
}
