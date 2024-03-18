using Microsoft.AspNetCore.Mvc;

namespace BitirmeProjesi.Controllers
{
    public class PersonelController : Controller
    {
        public IActionResult PersonelKayıt()
        {
            return View();
        }
    }
}
