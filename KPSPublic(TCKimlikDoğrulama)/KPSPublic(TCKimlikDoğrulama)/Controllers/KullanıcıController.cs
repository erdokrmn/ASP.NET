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
        bool result=false;
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
            result = response.Body.TCKimlikNoDogrulaResult;
            if (result==true)
            {
                ViewBag.result = result;
                
            }
            else
            {
                ViewBag.result = result;

            }
            return View();


        }


    }
}
