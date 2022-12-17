using KPSPublic_TCKimlikDoğrulama_.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Text;
using System.Xml.Linq;
using System.Xml.Serialization;
using System.Xml;

namespace KPSPublic_TCKimlikDoğrulama_.Controllers
{
    public class KullanıcıController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
       

        [HttpPost]
        public async Task<IActionResult> Index(Kullanıcı kullanıcı)
        {
            var client = new TcNoDoğrulama.KPSPublicSoapClient(TcNoDoğrulama.KPSPublicSoapClient.EndpointConfiguration.KPSPublicSoap);
            var response = await client.TCKimlikNoDogrulaAsync(kullanıcı.TCKimlikNo, kullanıcı.Ad, kullanıcı.Soyad, kullanıcı.DogumYılı);
            var result = response.Body.TCKimlikNoDogrulaResult;
            ViewResult resultTrue = View("true");
            int a = 5 + 4 + 3;
            if (result==true)
            {
                return resultTrue;
            }
            return View();


        }


    }
}
