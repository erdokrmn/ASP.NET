using BitirmeProjesi.Models.ViewModel;
using BitirmeProjesi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BitirmeProjesi.DataContext;

namespace BitirmeProjesi.Controllers
{
	public class MasrafController : Controller
	{
		private readonly BitirmeProjesiDbContext DbContext;

		public MasrafController(BitirmeProjesiDbContext DbContext)
		{
			this.DbContext = DbContext;
		}
		public IActionResult MasrafKayıt()
		{
			return View();
		}
		[HttpGet]
		public async Task<IActionResult> MasrafListeleme()
		{
			var masraflar = await DbContext.Masraflar.ToListAsync();

			return View(masraflar);


		}

		[HttpPost]
		public async Task<IActionResult> MasrafKayıt(Masraf addMasrafRequest)
		{
			//Kayıt kısmı
			var masraf = new Masraf()
			{
				Id = Guid.NewGuid(),
				MasrafAdı = addMasrafRequest.MasrafAdı,
				MasrafTipi = addMasrafRequest.MasrafTipi,
				MasrafTutarı = addMasrafRequest.MasrafTutarı,
				MasrafTarihi = addMasrafRequest.MasrafTarihi,

			};
			await DbContext.Masraflar.AddAsync(masraf);
			await DbContext.SaveChangesAsync();

			return RedirectToAction("MasrafListeleme");
		}

		[HttpGet]
		public async Task<IActionResult> MasrafDuzenleme(Guid id)
		{
			//Güncelleme kısmına seçtiğimiz veriyi aktardığımız kısım
			var masraf = await DbContext.Masraflar.FirstOrDefaultAsync(x => x.Id == id);
			if (masraf != null)
			{
				var viewModel = new Masraf()
				{
					Id = masraf.Id,
					MasrafAdı = masraf.MasrafAdı,
					MasrafTipi = masraf.MasrafTipi,
					MasrafTutarı = masraf.MasrafTutarı,
					MasrafTarihi = masraf.MasrafTarihi,

				};
				return await Task.Run(() => View("MasrafDuzenleme", viewModel));
			}
			return RedirectToAction("MasrafListeleme");
		}
		[HttpPost]
		public async Task<IActionResult> Delete(Masraf updateMasrafViewModel)
		{
			//silme kısmı
			var masraf = DbContext.Masraflar.Find(updateMasrafViewModel.Id);
			if (masraf != null)
			{
				DbContext.Masraflar.Remove(masraf);
				await DbContext.SaveChangesAsync();
				return RedirectToAction("MasrafListeleme");
			}

			return RedirectToAction("MasrafListeleme");
		}

		[HttpPost]
		public async Task<IActionResult> MasrafDuzenleme(Masraf updateMasrafViewModel)
		{
			//Düzenleme yapılan kısım
			var masraf = DbContext.Masraflar.Find(updateMasrafViewModel.Id);
			if (masraf != null)
			{
				masraf.MasrafAdı = updateMasrafViewModel.MasrafAdı;
				masraf.MasrafTipi = updateMasrafViewModel.MasrafTipi;
				masraf.MasrafTutarı = updateMasrafViewModel.MasrafTutarı;
				masraf.MasrafTarihi = updateMasrafViewModel.MasrafTarihi;


				await DbContext.SaveChangesAsync();

			}
			return RedirectToAction("MasrafListeleme");


		}
	}
}
