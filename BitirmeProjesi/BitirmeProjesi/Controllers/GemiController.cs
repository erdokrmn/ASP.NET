using BitirmeProjesi.Models.ViewModel;
using BitirmeProjesi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BitirmeProjesi.DataContext;
using Microsoft.AspNetCore.Authorization;

namespace BitirmeProjesi.Controllers
{
    public class GemiController : Controller
    {
        private readonly BitirmeProjesiDbContext DbContext;

        public GemiController(BitirmeProjesiDbContext DbContext)
        {
            this.DbContext = DbContext;
        }

        [Authorize(Roles = "Admin,Muhendis")]
        public IActionResult GemiKayıt()
        {
            return View();
        }


		[HttpGet]
        [Authorize(Roles = "Admin,Muhendis")]
        public async Task<IActionResult> GemiListeleme()
		{
			var gemiler = await DbContext.Gemiler.ToListAsync();

			return View(gemiler);


		}

		[HttpPost]
        [Authorize(Roles = "Admin,Muhendis")]
        public async Task<IActionResult> GemiKayıt(Gemi addGemiRequest)
        {
			if (!ModelState.IsValid)
			{
				// Masraflar property'sine ait doğrulama hatalarını kaldır
				ModelState.Remove("gemiEnvanterileri");

				// Tekrar kontrol et
				if (!ModelState.IsValid)
				{
					return View(addGemiRequest);
				}
			}
			//Kayıt kısmı
			var gemi = new Gemi()
            {
                Id = Guid.NewGuid(),
                GemiAdı = addGemiRequest.GemiAdı,
                GemiTipi = addGemiRequest.GemiTipi,
				TershaneAdı = addGemiRequest.TershaneAdı,
				TahminiBitirmeSuresi = addGemiRequest.TahminiBitirmeSuresi,
                GemiyeBaslamaTarihi = addGemiRequest.GemiyeBaslamaTarihi,

            };
            await DbContext.Gemiler.AddAsync(gemi);
            await DbContext.SaveChangesAsync();

            return RedirectToAction("GemiListeleme");
        }

		[HttpGet]
        [Authorize(Roles = "Admin,Muhendis")]
        public async Task<IActionResult> GemiDuzenleme(Guid id)
		{
			//Güncelleme kısmına seçtiğimiz veriyi aktardığımız kısım
			var gemi = await DbContext.Gemiler.FirstOrDefaultAsync(x => x.Id == id);
			if (gemi != null)
			{
				var viewModel = new Gemi()
				{
					Id = gemi.Id,
					GemiAdı = gemi.GemiAdı,
					GemiTipi= gemi.GemiTipi,
					TershaneAdı = gemi.TershaneAdı,
					TahminiBitirmeSuresi = gemi.TahminiBitirmeSuresi,
					GemiyeBaslamaTarihi = gemi.GemiyeBaslamaTarihi,
					
				};
				return await Task.Run(() => View("GemiDuzenleme", viewModel));
			}
			return RedirectToAction("PersonelListeleme");
		}

		[HttpPost]
        [Authorize(Roles = "Admin,Muhendis")]
        public async Task<IActionResult> Delete(Gemi updateGemiViewModel)
		{
			//silme kısmı
			var gemi = DbContext.Gemiler.Find(updateGemiViewModel.Id);
			if (gemi != null)
			{
				DbContext.Gemiler.Remove(gemi);
				await DbContext.SaveChangesAsync();
				return RedirectToAction("GemiListeleme");
			}

			return RedirectToAction("GemiListeleme");
		}

		[HttpPost]
        [Authorize(Roles = "Admin,Muhendis")]
        public async Task<IActionResult> GemiDuzenleme(Gemi updateGemiViewModel)
		{
			if (!ModelState.IsValid)
			{
				// Masraflar property'sine ait doğrulama hatalarını kaldır
				ModelState.Remove("gemiEnvanterileri");

				// Tekrar kontrol et
				if (!ModelState.IsValid)
				{
					return View(updateGemiViewModel);
				}
			}
			//Düzenleme yapılan kısım
			var gemi = DbContext.Gemiler.Find(updateGemiViewModel.Id);
			if (gemi != null)
			{
				gemi.GemiAdı = updateGemiViewModel.GemiAdı;
				gemi.GemiTipi = updateGemiViewModel.GemiTipi;
				gemi.TahminiBitirmeSuresi = updateGemiViewModel.TahminiBitirmeSuresi;
				gemi.GemiyeBaslamaTarihi = updateGemiViewModel.GemiyeBaslamaTarihi;
				

				await DbContext.SaveChangesAsync();

			}
			return RedirectToAction("GemiListeleme");


		}


	}
}
