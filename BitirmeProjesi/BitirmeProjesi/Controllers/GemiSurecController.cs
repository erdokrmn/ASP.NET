using BitirmeProjesi.DataContext;
using BitirmeProjesi.Models;
using BitirmeProjesi.Models.ViewModel;
using Microsoft.AspNetCore.Authorization;
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
        [Authorize(Roles = "Admin,Muhasebeci,Puantor,Muhendis")]
        public async Task<IActionResult> GemiSurecListeleme()
		{
			// GemiSurec tablosundan gerekli verileri çekiyoruz ve ilişkili tablolardan gerekli bilgileri join yaparak alıyoruz
			var gemiSurecListe = await DbContext.GemiSurecleri
				.Include(gs => gs.GemiEnvanteri) // GemiEnvanteri ile ilişkilendirme
				.Include(gs => gs.Personel) // Personel ile ilişkilendirme
				.Select(gs => new GemiSurecListelemeViewModel
				{
                    Id=gs.Id,
					AdSoyad = gs.Personel.Ad + " " + gs.Personel.Soyad,
					GemiParcaAdı = gs.GemiEnvanteri.ParcaAdı,
					Durum = gs.Durum,
					Tarih = gs.Tarih
				})
				.ToListAsync();

			return View(gemiSurecListe);
		}

        [HttpPost]
        [Authorize(Roles = "Admin,Muhendis")]
        public async Task<IActionResult> DeleteGemiSurec(Guid id)
        {
            var gemiSurec = await DbContext.GemiSurecleri.FindAsync(id);
            if (gemiSurec != null)
            {
                DbContext.GemiSurecleri.Remove(gemiSurec);
                await DbContext.SaveChangesAsync();
                return RedirectToAction("GemiSurecListeleme");
            }

            

            return RedirectToAction("GemiSurecListeleme");
        }
        [HttpGet]
        [Authorize(Roles = "Admin,Muhendis")]
        public async Task<IActionResult> GemiSurecKayıt()
        {
            // GemiEnvanteri'ni çekiyoruz ve GemiSureci tablosunda durumu "Bitti" olanları dışarıda bırakıyoruz
            var gemiEnvanterleri = await DbContext.GemiEnvanterleri
                .Where(ge => !DbContext.GemiSurecleri.Any(gs => gs.GemiEnvanteriId == ge.Id && gs.Durum == "Tamamlandi"))
                .Include(ge => ge.GemiAdı) // Gemi bilgisini çekiyoruz
                .ToListAsync();

            // Personelleri çekiyoruz
            var personeller = await DbContext.Personeller
                                        .Where(p => p.Yetki == "SahaElamanı")
                                        .ToListAsync();

            var viewModel = new GemiSurecViewModel
            {
                GemiEnvanterleri = gemiEnvanterleri,
                Personeller = personeller,
                GemiAdlari = await DbContext.Gemiler.ToDictionaryAsync(g => g.Id, g => g.GemiAdı)
            };

            return View(viewModel);
        }

        [HttpPost]
        [Authorize(Roles = "Admin,Muhendis")]
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
