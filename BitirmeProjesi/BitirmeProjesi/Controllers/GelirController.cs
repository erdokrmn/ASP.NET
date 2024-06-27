using BitirmeProjesi.DataContext;
using BitirmeProjesi.Models.ViewModel;
using BitirmeProjesi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace BitirmeProjesi.Controllers
{
    public class GelirController : Controller
    {
		private readonly BitirmeProjesiDbContext DbContext;

		public GelirController(BitirmeProjesiDbContext DbContext)
		{
			this.DbContext = DbContext;
		}
        [Authorize(Roles = "Admin,Muhasebeci")]
        public IActionResult GelirKayıt()
		{
			return View();
		}

        [Authorize(Roles = "Admin,Muhasebeci")]
        [HttpGet]
		public async Task<IActionResult> GelirListeleme()
		{
			var gelirler = await DbContext.Gelirler.ToListAsync();

			return View(gelirler);


		}

		[HttpPost]
        [Authorize(Roles = "Admin,Muhasebeci")]
        public async Task<IActionResult> GelirKayıt(Gelir addGelirRequest)
		{
            if (!ModelState.IsValid)
            {
                return View(addGelirRequest);
            }
            //Kayıt kısmı
            var gelir = new Gelir()
			{
				Id = Guid.NewGuid(),
				FaturaKesilenAd = addGelirRequest.FaturaKesilenAd,
				Miktar = addGelirRequest.Miktar,
				Kesinti = addGelirRequest.Kesinti,
				FaturaTarihi = addGelirRequest.FaturaTarihi,
				ÖdenmeTarihi = addGelirRequest.ÖdenmeTarihi,

			};
			await DbContext.Gelirler.AddAsync(gelir);
			await DbContext.SaveChangesAsync();

			return RedirectToAction("GelirListeleme");
		}

		[HttpGet]
        [Authorize(Roles = "Admin,Muhasebeci")]
        public async Task<IActionResult> GelirDuzenleme(Guid id)
		{
			//Güncelleme kısmına seçtiğimiz veriyi aktardığımız kısım
			var gelir = await DbContext.Gelirler.FirstOrDefaultAsync(x => x.Id == id);
			if (gelir != null)
			{
				var viewModel = new Gelir()
				{
					Id = gelir.Id,
					FaturaKesilenAd = gelir.FaturaKesilenAd,
					Miktar = gelir.Miktar,
					Kesinti = gelir.Kesinti,
					FaturaTarihi = gelir.FaturaTarihi,
					ÖdenmeTarihi = gelir.ÖdenmeTarihi,

				};
				return await Task.Run(() => View("GelirDuzenleme", viewModel));
			}
			return RedirectToAction("GelirListeleme");
		}

		[HttpPost]
        [Authorize(Roles = "Admin,Muhasebeci")]
        public async Task<IActionResult> Delete(Gelir updateGelirViewModel)
		{
			//silme kısmı
			var gelir = DbContext.Gelirler.Find(updateGelirViewModel.Id);
			if (gelir != null)
			{
				DbContext.Gelirler.Remove(gelir);
				await DbContext.SaveChangesAsync();
				return RedirectToAction("GelirListeleme");
			}

			return RedirectToAction("GelirListeleme");
		}


		[HttpPost]
        [Authorize(Roles = "Admin,Muhasebeci")]
        public async Task<IActionResult> GelirDuzenleme(Gelir updateGelirViewModel)
		{
            if (!ModelState.IsValid)
            {
                return View(updateGelirViewModel);
            }
            //Düzenleme yapılan kısım
            var gelir = DbContext.Gelirler.Find(updateGelirViewModel.Id);
			if (gelir != null)
			{
				gelir.FaturaKesilenAd = updateGelirViewModel.FaturaKesilenAd;
				gelir.Miktar = updateGelirViewModel.Miktar;
				gelir.Kesinti = updateGelirViewModel.Kesinti;
				gelir.FaturaTarihi = updateGelirViewModel.FaturaTarihi;
				gelir.ÖdenmeTarihi = updateGelirViewModel.ÖdenmeTarihi;


				await DbContext.SaveChangesAsync();

			}
			return RedirectToAction("GelirListeleme");


		}


	}

}
