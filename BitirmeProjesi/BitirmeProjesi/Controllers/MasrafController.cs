using BitirmeProjesi.Models.ViewModel;
using BitirmeProjesi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BitirmeProjesi.DataContext;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Authorization;

namespace BitirmeProjesi.Controllers
{
	public class MasrafController : Controller
	{
		private readonly BitirmeProjesiDbContext DbContext;

		public MasrafController(BitirmeProjesiDbContext DbContext)
		{
			this.DbContext = DbContext;
		}

        [Authorize(Roles = "Admin,Muhasebeci")]
        public IActionResult MasrafKayıt()
		{
            ViewBag.Firmalar = GetFirmalarSelectList();
            return View();
		}

	

		[HttpPost]
        [Authorize(Roles = "Admin,Muhasebeci")]
        public async Task<IActionResult> MasrafKayıt(Masraf addMasrafRequest)
		{
           
            if (!ModelState.IsValid)
            {
                // Masraflar property'sine ait doğrulama hatalarını kaldır
                ModelState.Remove("Firma");
                ModelState.Remove("MasrafTipi");
                // Tekrar kontrol et
                if (!ModelState.IsValid)
                {
                    ViewBag.Firmalar = GetFirmalarSelectList();
                    return View(addMasrafRequest);
                }
            }


            var masraf = new Masraf()
            {
                Id = Guid.NewGuid(),
                MasrafAdı = addMasrafRequest.MasrafAdı,
                MasrafTipi = addMasrafRequest.MasrafTipi,
                MasrafTutarı = addMasrafRequest.MasrafTutarı,
                ÖdemeTarihi = addMasrafRequest.ÖdemeTarihi,
                ÖdenenTarih = addMasrafRequest.ÖdenenTarih,
                FirmaId = addMasrafRequest.FirmaId,
            };

            await DbContext.Masraflar.AddAsync(masraf);
            await DbContext.SaveChangesAsync();

            return RedirectToAction("MasrafListeleme");
        }

        [HttpGet]
        [Authorize(Roles = "Admin,Muhasebeci")]
        public async Task<IActionResult> MasrafListeleme()
        {
            MasrafListelemeViewModel model = new MasrafListelemeViewModel();
            model.MasrafFirma = DbContext.Masraflar.Include(b => b.Firma).ToList();
            var masraflar = await DbContext.Masraflar.ToListAsync();

            return View(model);


        }

        [HttpGet]
        [Authorize(Roles = "Admin,Muhasebeci")]
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
        [Authorize(Roles = "Admin,Muhasebeci")]
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
        [Authorize(Roles = "Admin,Muhasebeci")]
        public async Task<IActionResult> MasrafDuzenleme(Masraf updateMasrafViewModel)
		{
            if (!ModelState.IsValid)
            {
                // Masraflar property'sine ait doğrulama hatalarını kaldır
                ModelState.Remove("Firma");
                ModelState.Remove("MasrafTipi");
                // Tekrar kontrol et
                if (!ModelState.IsValid)
                {
                    ViewBag.Firmalar = GetFirmalarSelectList();
                    return View(updateMasrafViewModel);
                }
            }

            //Düzenleme yapılan kısım
            var masraf = DbContext.Masraflar.Find(updateMasrafViewModel.Id);
			if (masraf != null)
			{
				masraf.MasrafAdı = updateMasrafViewModel.MasrafAdı;
				masraf.MasrafTipi = updateMasrafViewModel.MasrafTipi;
				masraf.MasrafTutarı = updateMasrafViewModel.MasrafTutarı;
				masraf.ÖdemeTarihi = masraf.ÖdemeTarihi;
				masraf.ÖdenenTarih = updateMasrafViewModel.ÖdenenTarih;
				masraf.FirmaId = updateMasrafViewModel.FirmaId;


				await DbContext.SaveChangesAsync();

			}
			return RedirectToAction("MasrafListeleme");


		}


        private List<SelectListItem> GetFirmalarSelectList()
        {
            return DbContext.Firmalar
                .Select(x => new SelectListItem
                {
                    Text = x.FirmaAdı,
                    Value = x.Id.ToString()
                })
                .ToList();
        }

    }
}
