using Biletleme.Data;
using Biletleme.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Dynamic.Core;

namespace Biletleme.Controllers
{
    
    public class MusterilerController : Controller
    {
        private readonly MVCDemoDbContext mvcDemoDbContext;

        public MusterilerController(MVCDemoDbContext mvcDemoDbContext)
        {
            this.mvcDemoDbContext = mvcDemoDbContext;
        }
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            //Listeleme kısmı 
            var musteriler = await mvcDemoDbContext.Musteriler.ToListAsync();

            return View(musteriler);

        }

        [HttpGet]
        public async Task<IActionResult> View(Guid id)
        {
            //Güncelleme kısmına seçtiğimiz veriyi aktardığımız kısım
            var musteri = await mvcDemoDbContext.Musteriler.FirstOrDefaultAsync(x => x.Id == id);
            if (musteri != null)
            {
                var viewModel = new UpdateMusteriViewModel()
                {
                    Id = musteri.Id,
                    Ad = musteri.Ad,
                    Soyad = musteri.Soyad,
                    DoğumTarihi = musteri.DoğumTarihi,
                    TelNo = musteri.TelNo,
                    EMail = musteri.EMail,
                    KayıtTarihi = musteri.KayıtTarihi,
                    Durum = musteri.Durum
                };
                return await Task.Run(() => View("View", viewModel));
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Delete(UpdateMusteriViewModel updateMusteriViewModel)
        {
            //silme kısmı
            var musteri = mvcDemoDbContext.Musteriler.Find(updateMusteriViewModel.Id);
            if (musteri != null)
            {
                mvcDemoDbContext.Musteriler.Remove(musteri);
                await mvcDemoDbContext.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> View(UpdateMusteriViewModel updateMusteriViewModel)
        {
            //Düzenleme yapılan kısım
            var musteri = await mvcDemoDbContext.Musteriler.FindAsync(updateMusteriViewModel.Id);
            if (musteri != null)
            {
                musteri.Ad = updateMusteriViewModel.Ad;
                musteri.Soyad = updateMusteriViewModel.Soyad;
                musteri.DoğumTarihi = updateMusteriViewModel.DoğumTarihi;
                musteri.TelNo = updateMusteriViewModel.TelNo;
                musteri.EMail = updateMusteriViewModel.EMail;
                musteri.KayıtTarihi = updateMusteriViewModel.KayıtTarihi;
                musteri.Durum = updateMusteriViewModel.Durum;

                await mvcDemoDbContext.SaveChangesAsync();

            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddMusteriViewModel addMusteriRequest)
        {
            //Kayıt kısmı
            var musteri = new Musteri()
            {
                Id = Guid.NewGuid(),
                Ad = addMusteriRequest.Ad,
                Soyad = addMusteriRequest.Soyad,
                DoğumTarihi = addMusteriRequest.DoğumTarihi,
                TelNo = addMusteriRequest.TelNo,
                EMail = addMusteriRequest.EMail,
                KayıtTarihi = addMusteriRequest.KayıtTarihi,
                Durum = addMusteriRequest.Durum
            };
            await mvcDemoDbContext.Musteriler.AddAsync(musteri);
            await mvcDemoDbContext.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        
    }
}
