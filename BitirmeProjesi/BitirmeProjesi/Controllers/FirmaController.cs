using BitirmeProjesi.DataContext;
using BitirmeProjesi.Models.ViewModel;
using BitirmeProjesi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Authorization;
using System.ComponentModel.DataAnnotations;

namespace BitirmeProjesi.Controllers
{
	public class FirmaController : Controller
	{
		private readonly BitirmeProjesiDbContext DbContext;

		public FirmaController(BitirmeProjesiDbContext DbContext)
		{
			this.DbContext = DbContext;
		}


        [HttpGet]
        [Authorize(Roles = "Admin,Muhasebeci")]
        public IActionResult FirmaKayıt()
		{
            return View();
		}

		[HttpGet]
        [Authorize(Roles = "Admin,Muhasebeci")]
        public async Task<IActionResult> FirmaListeleme()
		{
			var firmalar = await DbContext.Firmalar.ToListAsync();

			return View(firmalar);


		}

       
        [HttpPost]
        [Authorize(Roles = "Admin,Muhasebeci")]

        public async Task<IActionResult> FirmaKayıt(Firma addFirmaRequest)
		{
            if (!ModelState.IsValid)
            {
                // Masraflar property'sine ait doğrulama hatalarını kaldır
                ModelState.Remove("Masraflar");

                // Tekrar kontrol et
                if (!ModelState.IsValid)
                {
                    return View(addFirmaRequest);
                }
            }

            var firma = new Firma()
            {
                Id = Guid.NewGuid(),
                FirmaAdı = addFirmaRequest.FirmaAdı,
                TelofonNo = addFirmaRequest.TelofonNo,
                Iban = addFirmaRequest.Iban,
                İlgiliKisi = addFirmaRequest.İlgiliKisi,
                //Masraflar = new List<Masraf>() // Varsayılan olarak boş koleksiyon
            };

            DbContext.Firmalar.Add(firma);
            await DbContext.SaveChangesAsync();

            return RedirectToAction("FirmaListeleme");
        }

	

		[HttpPost]
        [Authorize(Roles = "Admin,Muhasebeci")]
        public async Task<IActionResult> Delete(Firma updateFirma)
		{
            var firma = await DbContext.Firmalar.FindAsync(updateFirma.Id);
            if (firma == null)
            {
                return NotFound();
            }

            DbContext.Firmalar.Remove(firma);
            await DbContext.SaveChangesAsync();

            return RedirectToAction("FirmaListeleme");
        }


        [HttpGet]
        [Authorize(Roles = "Admin,Muhasebeci")]
        public async Task<IActionResult> FirmaDuzenleme(Guid id)
        {

            // Güncelleme kısmına seçtiğimiz veriyi aktardığımız kısım
            var firma = await DbContext.Firmalar.FirstOrDefaultAsync(x => x.Id == id);
            if (firma != null)
            {
                var viewModel = new Firma()
                {
                    Id = firma.Id,
                    FirmaAdı = firma.FirmaAdı,
                    TelofonNo = firma.TelofonNo,
                    Iban = firma.Iban,
                    İlgiliKisi = firma.İlgiliKisi,
                };
                return View(viewModel);
            }
            return RedirectToAction("FirmaListeleme");
        }

        [HttpPost]
        [Authorize(Roles = "Admin,Muhasebeci")]
        public async Task<IActionResult> FirmaDuzenleme(Firma updateFirma)
		{

            if (!ModelState.IsValid)
            {
                // Masraflar property'sine ait doğrulama hatalarını kaldır
                ModelState.Remove("Masraflar");

                // Tekrar kontrol et
                if (!ModelState.IsValid)
                {
                    return View(updateFirma);
                }
            }

            var firma = await DbContext.Firmalar.FindAsync(updateFirma.Id);
            if (firma == null)
            {
                // Firma bulunamadıysa, hata mesajı döndürelim
                ModelState.AddModelError("", "Firma bulunamadı.");
                return View(updateFirma);
            }

            firma.FirmaAdı = updateFirma.FirmaAdı;
            firma.TelofonNo = updateFirma.TelofonNo;
            firma.Iban = updateFirma.Iban;
            firma.İlgiliKisi = updateFirma.İlgiliKisi;

            try
            {
                await DbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                // Hata durumunda, ModelState'e hata ekleyelim ve kullanıcıya döndürelim
                ModelState.AddModelError("", $"Hata: {ex.Message}");
                return View(updateFirma);
            }

            return RedirectToAction("FirmaListeleme");


        }


	}
}

