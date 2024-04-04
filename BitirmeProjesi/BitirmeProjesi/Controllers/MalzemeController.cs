﻿using BitirmeProjesi.Models.ViewModel;
using BitirmeProjesi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BitirmeProjesi.DataContext;

namespace BitirmeProjesi.Controllers
{
	public class MalzemeController : Controller
	{

		private readonly BitirmeProjesiDbContext DbContext;

		public MalzemeController(BitirmeProjesiDbContext DbContext)
		{
			this.DbContext = DbContext;
		}
		public IActionResult MalzemeKayıt()
		{
			return View();
		}
		[HttpGet]
		public async Task<IActionResult> MalzemeListeleme()
		{
			var malzemeler = await DbContext.Malzemeler.ToListAsync();

			return View(malzemeler);


		}

		[HttpPost]
		public async Task<IActionResult> MalzemeKayıt(Malzeme addMalzemeRequest)
		{
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
		public async Task<IActionResult> MalzemeDuzenleme(Malzeme updateMalzemeViewModel)
		{
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