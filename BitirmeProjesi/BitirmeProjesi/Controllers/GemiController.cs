using BitirmeProjesi.Models.ViewModel;
using BitirmeProjesi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BitirmeProjesi.DataContext;

namespace BitirmeProjesi.Controllers
{
    public class GemiController : Controller
    {
        private readonly BitirmeProjesiDbContext DbContext;

        public GemiController(BitirmeProjesiDbContext DbContext)
        {
            this.DbContext = DbContext;
        }
        public IActionResult GemiKayıt()
        {
            return View();
        }
		[HttpGet]
		public async Task<IActionResult> GemiListeleme()
		{
			var gemiler = await DbContext.Gemiler.ToListAsync();

			return View(gemiler);


		}

		[HttpPost]
        public async Task<IActionResult> GemiKayıt(Gemi addGemiRequest)
        {
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
		public async Task<IActionResult> Delete(GemiViewModel updateGemiViewModel)
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
		public async Task<IActionResult> GemiDuzenleme(GemiViewModel updateGemiViewModel)
		{
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
