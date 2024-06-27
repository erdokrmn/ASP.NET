using BitirmeProjesi.Models.ViewModel;
using BitirmeProjesi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BitirmeProjesi.DataContext;
using Microsoft.AspNetCore.Authorization;

namespace BitirmeProjesi.Controllers
{
	public class MalzemeController : Controller
	{

		private readonly BitirmeProjesiDbContext DbContext;

		public MalzemeController(BitirmeProjesiDbContext DbContext)
		{
			this.DbContext = DbContext;
		}
        [Authorize(Roles = "Admin,Muhendis,Depocu")]
        public IActionResult MalzemeKayıt()
		{
			return View();
		}
        [Authorize(Roles = "Admin,Muhendis,Depocu")]
        [HttpGet]
		public async Task<IActionResult> MalzemeListeleme()
		{
			var malzemeler = await DbContext.Malzemeler.ToListAsync();

			return View(malzemeler);


		}

        [Authorize(Roles = "Admin,Muhendis,Depocu")]
        [HttpPost]
		public async Task<IActionResult> MalzemeKayıt(Malzeme addMalzemeRequest)
		{
			if (!ModelState.IsValid)
			{
				// Masraflar property'sine ait doğrulama hatalarını kaldır
				ModelState.Remove("MalzemeTürü");
				ModelState.Remove("MalzemeKodu");
				ModelState.Remove("ZimmetEdilenMalzemeler");

				// Tekrar kontrol et
				if (!ModelState.IsValid)
				{
					return View(addMalzemeRequest);
				}
			}
			//Kayıt kısmı
			var malzeme = new Malzeme()
			{
				Id = Guid.NewGuid(),
				MalzemeAdı = addMalzemeRequest.MalzemeAdı,
				MalzemeTürü = addMalzemeRequest.MalzemeTürü,
				MalzemeSkt = addMalzemeRequest.MalzemeSkt,
				MalzemeAdet = addMalzemeRequest.MalzemeAdet,
				MalzemeFiyatı = addMalzemeRequest.MalzemeFiyatı,
				MalzemeKodu = addMalzemeRequest.MalzemeKodu,
				MalzemeAlınısTarih = addMalzemeRequest.MalzemeAlınısTarih,
				ÜrünDurumu = addMalzemeRequest.ÜrünDurumu,

			};
			await DbContext.Malzemeler.AddAsync(malzeme);
			await DbContext.SaveChangesAsync();

			return RedirectToAction("MalzemeListeleme");
		}

		[HttpGet]
        [Authorize(Roles = "Admin,Muhendis,Depocu")]
        public async Task<IActionResult> MalzemeDuzenleme(Guid id)
		{
			//Güncelleme kısmına seçtiğimiz veriyi aktardığımız kısım
			var malzeme = await DbContext.Malzemeler.FirstOrDefaultAsync(x => x.Id == id);
			if (malzeme != null)
			{
				var viewModel = new Malzeme()
				{
					Id = malzeme.Id,
					MalzemeAdı = malzeme.MalzemeAdı,
					MalzemeTürü = malzeme.MalzemeTürü,
					MalzemeSkt = malzeme.MalzemeSkt,
					MalzemeAdet = malzeme.MalzemeAdet,
					MalzemeFiyatı = malzeme.MalzemeFiyatı,
					MalzemeKodu = malzeme.MalzemeKodu,
					MalzemeAlınısTarih = malzeme.MalzemeAlınısTarih,
					ÜrünDurumu = malzeme.ÜrünDurumu,

				};
				return await Task.Run(() => View("MalzemeDuzenleme", viewModel));
			}
			return RedirectToAction("MalzemeListeleme");
		}

		[HttpPost]
        [Authorize(Roles = "Admin,Muhendis,Depocu")]
        public async Task<IActionResult> Delete(Malzeme updateMalzemeViewModel)
		{
			//silme kısmı
			var malzeme = DbContext.Malzemeler.Find(updateMalzemeViewModel.Id);
			if (malzeme != null)
			{
				DbContext.Malzemeler.Remove(malzeme);
				await DbContext.SaveChangesAsync();
				return RedirectToAction("MalzemeListeleme");
			}

			return RedirectToAction("MalzemeListeleme");
		}

		[HttpPost]
        [Authorize(Roles = "Admin,Muhendis,Depocu")]
        public async Task<IActionResult> MalzemeDuzenleme(Malzeme updateMalzemeViewModel)
		{
			if (!ModelState.IsValid)
			{
				// Masraflar property'sine ait doğrulama hatalarını kaldır
				ModelState.Remove("MalzemeTürü");
				ModelState.Remove("MalzemeKodu");
				ModelState.Remove("ZimmetEdilenMalzemeler");

				// Tekrar kontrol et
				if (!ModelState.IsValid)
				{
					return View(updateMalzemeViewModel);
				}
			}
			//Düzenleme yapılan kısım
			var malzeme = DbContext.Malzemeler.Find(updateMalzemeViewModel.Id);
			if (malzeme != null)
			{
				malzeme.MalzemeAdı = updateMalzemeViewModel.MalzemeAdı;
				malzeme.MalzemeTürü = updateMalzemeViewModel.MalzemeTürü;
				malzeme.MalzemeSkt = updateMalzemeViewModel.MalzemeSkt;
				malzeme.MalzemeAdet = updateMalzemeViewModel.MalzemeAdet;
				malzeme.MalzemeFiyatı = updateMalzemeViewModel.MalzemeFiyatı;
				malzeme.MalzemeKodu = updateMalzemeViewModel.MalzemeKodu;
				malzeme.MalzemeAlınısTarih = updateMalzemeViewModel.MalzemeAlınısTarih;
				malzeme.ÜrünDurumu = updateMalzemeViewModel.ÜrünDurumu;


				await DbContext.SaveChangesAsync();

			}
			return RedirectToAction("MalzemeListeleme");


		}
	}
}
