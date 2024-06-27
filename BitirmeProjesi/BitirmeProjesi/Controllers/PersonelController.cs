﻿using BitirmeProjesi.DataContext;
using BitirmeProjesi.Models;
using BitirmeProjesi.Models.ViewModel;
using Microsoft.AspNetCore.Authorization;
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
        [Authorize(Roles = "Admin,Muhasebeci,Puantor")]
        public IActionResult PersonelKayıt()
        {
          
                // Personel property'sine ait doğrulama hatalarını kaldır
                ModelState.Remove("IstenAyrılmaTarihi");
                ModelState.Remove("Maaslar");
                ModelState.Remove("GCler");
                ModelState.Remove("GemiSurecleri");
                ModelState.Remove("ZimmetEdilenPersoneller");
                // Tekrar kontrol et
                return View();
           

        }

        [HttpPost]
        [Authorize(Roles = "Admin,Muhasebeci,Puantor")]
        public async Task<IActionResult> PersonelKayıt(PersonelViewModel addPersonelRequest)
        {
            if (!ModelState.IsValid)
            {
                // Personel property'sine ait doğrulama hatalarını kaldır
                ModelState.Remove("IstenAyrılmaTarihi");
                ModelState.Remove("Maaslar");
                ModelState.Remove("GCler");
                ModelState.Remove("GemiSurecleri");
                ModelState.Remove("ZimmetEdilenPersoneller");
                // Tekrar kontrol et
                if (!ModelState.IsValid)
                {
                    return View(addPersonelRequest);
                }
            }
            //Kayıt kısmı
            var personel = new Personel()
            {
                Id = Guid.NewGuid(),
                Ad = addPersonelRequest.Ad,
                Soyad = addPersonelRequest.Soyad,
                TcNo = addPersonelRequest.TcNo,
                TelefonNo = addPersonelRequest.TelefonNo,
				Maas = addPersonelRequest.Maas,
				Yetki = addPersonelRequest.Yetki,
				KanGrubu = addPersonelRequest.KanGrubu,
                DoğumYeri = addPersonelRequest.DoğumYeri,
                Il = addPersonelRequest.Il,
                Ilce = addPersonelRequest.Ilce,
                Adres = addPersonelRequest.Adres,
                Cinsiyet = addPersonelRequest.Cinsiyet,
                DoğumYılı = addPersonelRequest.DoğumYılı,
                EDevletŞifre = addPersonelRequest.EDevletŞifre,
                CalıstıgıTershane = addPersonelRequest.CalıstıgıTershane,
                AcilDurumdaUlaşılacakKişiNo = addPersonelRequest.AcilDurumdaUlaşılacakKişiNo,
                IseBaslamaTarihi = addPersonelRequest.IseBaslamaTarihi,
                CalısmaDurumu = true,


            };
            await DbContext.Personeller.AddAsync(personel);
            await DbContext.SaveChangesAsync();
            return RedirectToAction("PersonelListeleme");
        }

        [HttpGet]
        [Authorize(Roles = "Admin,Muhasebeci,Puantor")]
        public async Task<IActionResult> PersonelListeleme()
        {
            var personeller = await DbContext.Personeller.ToListAsync();

            return View(personeller);


        }

		[HttpGet]
        [Authorize(Roles = "Admin,Muhasebeci,Puantor")]
        public async Task<IActionResult> PersonelDuzenleme(Guid id)
		{
			//Güncelleme kısmına seçtiğimiz veriyi aktardığımız kısım
			var personel = await DbContext.Personeller.FirstOrDefaultAsync(x => x.Id == id);
			if (personel != null)
			{
				var viewModel = new PersonelViewModel()
				{
                    Id=personel.Id,
					Ad = personel.Ad,
					Soyad = personel.Soyad,
					TcNo = personel.TcNo,
					TelefonNo = personel.TelefonNo,
					Maas = personel.Maas,
					Yetki = personel.Yetki,
					KanGrubu = personel.KanGrubu,
					DoğumYeri = personel.DoğumYeri,
					Il = personel.Il,
					Ilce = personel.Ilce,
					Adres = personel.Adres,
					Cinsiyet = personel.Cinsiyet,
					DoğumYılı = personel.DoğumYılı,
					EDevletŞifre = personel.EDevletŞifre,
                    CalıstıgıTershane = personel.CalıstıgıTershane,
					AcilDurumdaUlaşılacakKişiNo = personel.AcilDurumdaUlaşılacakKişiNo,
					IseBaslamaTarihi = personel.IseBaslamaTarihi,
					IstenAyrılmaTarihi = personel.IstenAyrılmaTarihi,
					CalısmaDurumu = personel.CalısmaDurumu,
				};
				return await Task.Run(() => View("PersonelDuzenleme", viewModel));
			}
			return RedirectToAction("PersonelListeleme");
		}


		[HttpPost]
        [Authorize(Roles = "Admin,Muhasebeci,Puantor")]
        public async Task<IActionResult> Delete(PersonelViewModel updatePersonelViewModel)
        {
            //silme kısmı
            var personel = DbContext.Personeller.Find(updatePersonelViewModel.Id);
            if (personel != null)
            {
                DbContext.Personeller.Remove(personel);
                await DbContext.SaveChangesAsync();
                return RedirectToAction("PersonelListeleme");
            }

            return RedirectToAction("PersonelListeleme");
        }

        [HttpPost]
        [Authorize(Roles = "Admin,Muhasebeci,Puantor")]
        public async Task<IActionResult> PersonelDuzenleme(PersonelViewModel updatePersonelViewModel)
        {
            if (!ModelState.IsValid)
            {
                // Personel property'sine ait doğrulama hatalarını kaldır
                ModelState.Remove("IstenAyrılmaTarihi");
                ModelState.Remove("Maaslar");
                ModelState.Remove("GCler");
                ModelState.Remove("GemiSurecleri");
                ModelState.Remove("ZimmetEdilenPersoneller");
                // Tekrar kontrol et
                if (!ModelState.IsValid)
                {
                    return View(updatePersonelViewModel);
                }
            }
            //Düzenleme yapılan kısım
            var personel =  DbContext.Personeller.Find(updatePersonelViewModel.Id);
            if (personel != null)
            {
                personel.Ad = updatePersonelViewModel.Ad;
                personel.Soyad = updatePersonelViewModel.Soyad;
                personel.TcNo = updatePersonelViewModel.TcNo;
                personel.TelefonNo = updatePersonelViewModel.TelefonNo;
				personel.Maas = updatePersonelViewModel.Maas;
				personel.Yetki = updatePersonelViewModel.Yetki;
				personel.KanGrubu = updatePersonelViewModel.KanGrubu; 
                personel.DoğumYeri = updatePersonelViewModel.DoğumYeri;
				personel.Il = updatePersonelViewModel.Il;
				personel.Ilce = updatePersonelViewModel.Ilce;
				personel.Adres = updatePersonelViewModel.Adres;
				personel.Cinsiyet = updatePersonelViewModel.Cinsiyet;
				personel.DoğumYılı = updatePersonelViewModel.DoğumYılı;
				personel.EDevletŞifre = updatePersonelViewModel.EDevletŞifre;
				personel.CalıstıgıTershane = updatePersonelViewModel.CalıstıgıTershane;
				personel.AcilDurumdaUlaşılacakKişiNo = updatePersonelViewModel.AcilDurumdaUlaşılacakKişiNo;
				personel.IseBaslamaTarihi = updatePersonelViewModel.IseBaslamaTarihi;
				personel.IstenAyrılmaTarihi = updatePersonelViewModel.IstenAyrılmaTarihi;
				personel.CalısmaDurumu = updatePersonelViewModel.CalısmaDurumu;

				await DbContext.SaveChangesAsync();

            }
            return RedirectToAction("PersonelListeleme");


        }
    }
   
}
