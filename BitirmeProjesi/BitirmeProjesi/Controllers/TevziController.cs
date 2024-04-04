using BitirmeProjesi.DataContext;
using BitirmeProjesi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BitirmeProjesi.Models.ViewModel;

namespace BitirmeProjesi.Controllers
{
	public class TevziController : Controller
	{
		private readonly BitirmeProjesiDbContext DbContext;
		TevziListelemeViewModel tevzi=new TevziListelemeViewModel() ;

		public TevziController(BitirmeProjesiDbContext DbContext)
		{
			this.DbContext = DbContext;
		}
		[HttpGet]
		public async Task<IActionResult> TevziListeleme()
		{
			TevziListelemeViewModel model = new TevziListelemeViewModel();
			//Tevziler tablosuna personel tablosunun verilerini kullandırtığım kısım
			model.TevziPersonel = DbContext.Tevziler.Include(b => b.Personel).ToList();
			var tevziler = await DbContext.Tevziler.ToListAsync();
		
			return View(model);


		}

		[HttpGet]
		public async Task<IActionResult> TevziKayıt()
		{
			var viewModel= new TevziViewModel();

			viewModel.personeller = await DbContext.Personeller.ToListAsync();
			viewModel.tevzi = new Tevzi();

			return View(viewModel);


		}
		
		[HttpPost]
		public async Task<IActionResult> Kayıt(TevziViewModel addTevziRequest,Guid Id)
		{
				var tevzi = new Tevzi()
				{
					Id = Guid.NewGuid(),
					TevziTarih = addTevziRequest.tevzi.TevziTarih,
					CalısmaSaati = addTevziRequest.tevzi.CalısmaSaati,
					MesaiSaati = addTevziRequest.tevzi.MesaiSaati,
					Durum = addTevziRequest.tevzi.Durum,
					PersonelId = Id,

				};
				await DbContext.Tevziler.AddAsync(tevzi);
				await DbContext.SaveChangesAsync();


			return RedirectToAction("TevziKayıt");



		}

	}
}
