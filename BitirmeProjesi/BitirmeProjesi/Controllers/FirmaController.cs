﻿using BitirmeProjesi.DataContext;
using BitirmeProjesi.Models.ViewModel;
using BitirmeProjesi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Authorization;

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
        [Authorize(Roles = "Admin")]
        public IActionResult FirmaKayıt()
		{
          
            return View();
		}
		[HttpGet]
		public async Task<IActionResult> FirmaListeleme()
		{
			var firmalar = await DbContext.Firmalar.ToListAsync();

			return View(firmalar);


		}

       
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> FirmaKayıt(Firma addFirmaRequest)
		{
			//Kayıt kısmı
			var firma = new Firma()
			{
				Id = Guid.NewGuid(),
				FirmaAdı = addFirmaRequest.FirmaAdı,
				TelofonNo = addFirmaRequest.TelofonNo,
				Iban = addFirmaRequest.Iban,
				İlgiliKisi = addFirmaRequest.İlgiliKisi,

			};
			await DbContext.Firmalar.AddAsync(firma);
			await DbContext.SaveChangesAsync();

			return RedirectToAction("FirmaListeleme");
		}

		[HttpGet]
		public async Task<IActionResult> FirmaDuzenleme(Guid id)
		{
			//Güncelleme kısmına seçtiğimiz veriyi aktardığımız kısım
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
				return await Task.Run(() => View("FirmaDuzenleme", viewModel));
			}
			return RedirectToAction("FirmaListeleme");
		}
		[HttpPost]
		public async Task<IActionResult> Delete(Firma updateFirma)
		{
			//silme kısmı
			var firma = DbContext.Firmalar.Find(updateFirma.Id);
			if (firma != null)
			{
				DbContext.Firmalar.Remove(firma);
				await DbContext.SaveChangesAsync();
				return RedirectToAction("FirmaListeleme");
			}

			return RedirectToAction("FirmaListeleme");
		}

		[HttpPost]
		public async Task<IActionResult> FirmaDuzenleme(Firma updateFirma)
		{
			//Düzenleme yapılan kısım
			var firma = DbContext.Firmalar.Find(updateFirma.Id);
			if (firma != null)
			{
				firma.FirmaAdı = updateFirma.FirmaAdı;
				firma.TelofonNo = updateFirma.TelofonNo;
				firma.Iban = updateFirma.Iban;
				firma.İlgiliKisi = updateFirma.İlgiliKisi;


				await DbContext.SaveChangesAsync();

			}
			return RedirectToAction("FirmaListeleme");


		}


	}
}
