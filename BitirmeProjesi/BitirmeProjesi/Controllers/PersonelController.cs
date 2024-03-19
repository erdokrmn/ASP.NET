using BitirmeProjesi.DataContext;
using BitirmeProjesi.Models;
using BitirmeProjesi.Models.ViewModel;
using BitirmeProjesiEkranlar.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BitirmeProjesi.Controllers
{

    public class PersonelController : Controller
    {
        private readonly BitirmeProjesiDbContext DbContext;

        public PersonelController(BitirmeProjesiDbContext DbContext)
        {
            this.DbContext = DbContext;
        }
        [HttpGet]
        public IActionResult PersonelKayıt()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> PersonelKayıt(PersonelViewModel addPersonelRequest)
        {
            //Kayıt kısmı
            var personel = new Personel()
            {
                Id = Guid.NewGuid(),
                Ad = addPersonelRequest.Ad,
                Soyad = addPersonelRequest.Soyad,
                TcNo= addPersonelRequest.TcNo,
                TelefonNo= addPersonelRequest.TelefonNo,
                KanGrubu=addPersonelRequest.KanGrubu,   
                DoğumYeri=addPersonelRequest.DoğumYeri,
                Il=addPersonelRequest.Il,
                Ilce=addPersonelRequest.Ilce,
                Adres=addPersonelRequest.Adres,
                Cinsiyet=addPersonelRequest.Cinsiyet,
                DoğumYılı=addPersonelRequest.DoğumYılı,
                EDevletŞifre=addPersonelRequest.EDevletŞifre,
                EMail=addPersonelRequest.EMail,
                AcilDurumdaUlaşılacakKişiNo=addPersonelRequest.AcilDurumdaUlaşılacakKişiNo,
                IseBaslamaTarihi=addPersonelRequest.IseBaslamaTarihi,
                IstenAyrılmaTarihi=addPersonelRequest.IstenAyrılmaTarihi,
                CalısmaDurumu=addPersonelRequest.CalısmaDurumu,


            };
            await DbContext.Personeller.AddAsync(personel);
            await DbContext.SaveChangesAsync();
            return RedirectToAction("PersonelListeleme");
        }
        [HttpGet]
        public async Task<IActionResult> PersonelListeleme()
        {
            var personeller = await DbContext.Personeller.ToListAsync();

            return View(personeller);

            
        }

    }

   
}
