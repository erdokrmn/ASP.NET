using BitirmeProjesi.DataContext;
using BitirmeProjesi.Models;
using BitirmeProjesi.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BitirmeProjesi.Controllers
{
	public class GemiSurecController : Controller
	{

		private readonly BitirmeProjesiDbContext DbContext;

		public GemiSurecController(BitirmeProjesiDbContext DbContext)
		{
			this.DbContext = DbContext;
		}

        [HttpGet]
        public async Task<IActionResult> GemiSurecKayıt()
        {
            // GemiEnvanteri'ni çekiyoruz ve GemiSureci tablosunda durumu "Bitti" olanları dışarıda bırakıyoruz
            var gemiEnvanterleri = await DbContext.GemiEnvanterleri
                .Where(ge => !DbContext.GemiSurecleri.Any(gs => gs.GemiEnvanteriId == ge.Id && gs.Durum == "Tamamlandi"))
                .Include(ge => ge.GemiAdı) // Gemi bilgisini çekiyoruz
                .ToListAsync();

            // Personelleri çekiyoruz
            var personeller = await DbContext.Personeller.ToListAsync();

            var viewModel = new GemiSurecViewModel
            {
                GemiEnvanterleri = gemiEnvanterleri,
                Personeller = personeller,
                GemiAdlari = await DbContext.Gemiler.ToDictionaryAsync(g => g.Id, g => g.GemiAdı)
            };

            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> KayıtGemiSurec(GemiSurecFormViewModel formModel)
        {
            foreach (var personelId in formModel.PersonelIds)
            {
                var existingGemiSurec = await DbContext.GemiSurecleri
                    .FirstOrDefaultAsync(gs => gs.GemiEnvanteriId == formModel.GemiEnvanteriId && (gs.Durum == "Baslamadi" || gs.Durum== "Devam"));

                if (existingGemiSurec != null)
                {
                    // Mevcut kaydı güncelle
                    existingGemiSurec.Durum = formModel.Durum;
                    existingGemiSurec.Tarih = formModel.Tarih;
                    DbContext.GemiSurecleri.Update(existingGemiSurec);
                }
                else
                {
                    // Yeni kayıt oluştur
                    var gemiSurec = new GemiSurec
                    {
                        Id = Guid.NewGuid(),
                        GemiEnvanteriId = formModel.GemiEnvanteriId,
                        PersonelId = personelId,
                        Durum = formModel.Durum,
                        Tarih = formModel.Tarih
                    };
                    DbContext.GemiSurecleri.Add(gemiSurec);
                }
            }

            await DbContext.SaveChangesAsync();
            return RedirectToAction("GemiSurecKayıt");
        }
    }
}
