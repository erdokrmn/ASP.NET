using BitirmeProjesi.Models.ViewModel;
using BitirmeProjesi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BitirmeProjesi.DataContext;
using Microsoft.AspNetCore.Mvc.Rendering;

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
            List<SelectListItem> firmalar = (from x in DbContext.Firmalar.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = x.FirmaAdı,
                                                 Value = x.Id.ToString()
                                             }).ToList();
            ViewBag.Firmalar = firmalar;
            return View();
		}
		[HttpGet]
		public async Task<IActionResult> MasrafListeleme()
		{
			MasrafListelemeViewModel model = new MasrafListelemeViewModel();
			model.MasrafFirma = DbContext.Masraflar.Include(b => b.Firma).ToList();
			var masraflar = await DbContext.Masraflar.ToListAsync();

			return View(model);


		}

		[HttpPost]
		public async Task<IActionResult> MasrafKayıt(MasrafViewModel addMasrafRequest)
		{
			var SelectedFirmaId = addMasrafRequest.firmalar.Id;
			// alttaki ile kontrol yapıcam ileride
			var Selectedmalzeme = DbContext.Malzemeler.Find(SelectedFirmaId);

			//Kayıt kısmı
			var masraf = new Masraf()
			{
				Id = Guid.NewGuid(),
				MasrafAdı = addMasrafRequest.masraflar.MasrafAdı,
				MasrafTipi = addMasrafRequest.masraflar.MasrafTipi,
				MasrafTutarı = addMasrafRequest.masraflar.MasrafTutarı,
				ÖdemeTarihi = addMasrafRequest.masraflar.ÖdemeTarihi,
				ÖdenenTarih = addMasrafRequest.masraflar.ÖdenenTarih,
				FirmaId= SelectedFirmaId,




			};
			await DbContext.Masraflar.AddAsync(masraf);
			await DbContext.SaveChangesAsync();

			return RedirectToAction("MasrafListeleme");
		}

		[HttpGet]
		public async Task<IActionResult> MasrafDuzenleme(Guid id)
		{
            List<SelectListItem> firmalar = (from x in DbContext.Firmalar.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = x.FirmaAdı,
                                                 Value = x.Id.ToString()
                                             }).ToList();
            ViewBag.Firmalar = firmalar;
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
					ÖdemeTarihi = masraf.ÖdemeTarihi,
					ÖdenenTarih = masraf.ÖdenenTarih,
					FirmaId = masraf.FirmaId,

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
			var SelectedFirmaId = updateMasrafViewModel.FirmaId;

			//Düzenleme yapılan kısım
			var masraf = DbContext.Masraflar.Find(updateMasrafViewModel.Id);
			if (masraf != null)
			{
				masraf.MasrafAdı = updateMasrafViewModel.MasrafAdı;
				masraf.MasrafTipi = updateMasrafViewModel.MasrafTipi;
				masraf.MasrafTutarı = updateMasrafViewModel.MasrafTutarı;
				masraf.ÖdemeTarihi = masraf.ÖdemeTarihi;
				masraf.ÖdenenTarih = masraf.ÖdenenTarih;
				masraf.FirmaId = SelectedFirmaId;


				await DbContext.SaveChangesAsync();

			}
			return RedirectToAction("MasrafListeleme");


		}
	}
}
