using BitirmeProjesi.DataContext;
using BitirmeProjesi.Models.ViewModel;
using BitirmeProjesi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq.Dynamic.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace BitirmeProjesi.Controllers
{
	public class ZimmetController : Controller
	{
		private readonly BitirmeProjesiDbContext DbContext;

		public ZimmetController(BitirmeProjesiDbContext DbContext)
		{
			this.DbContext = DbContext;
		}

		[HttpGet]
        [Authorize(Roles = "Admin,Depocu,Muhendis")]
        public IActionResult ZimmetKayıt()
		{
            List<SelectListItem> malzemeler = (from x in DbContext.Malzemeler.ToList()
                                               select new SelectListItem
                                               {
                                                   Text = x.MalzemeAdı,
                                                   Value = x.Id.ToString()
                                               }).ToList();
            ViewBag.Malzemeler = malzemeler;

            List<SelectListItem> personeller = (from x in DbContext.Personeller.ToList()
                                                select new SelectListItem
                                                {
                                                    Text = x.Ad,
                                                    Value = x.Id.ToString()
                                                }).ToList();
            ViewBag.Personeller = personeller;


            return View();
		}


        [HttpPost]
        [Authorize(Roles = "Admin,Depocu,Muhendis")]
        public async Task<IActionResult> ZimmetKayıt(ZimmetViewModel addZimmetRequest)
        {
            var SelectedmalzemeId = addZimmetRequest.malzemeler.Id;
            var Selectedmalzeme = DbContext.Malzemeler.Find(SelectedmalzemeId);
            var SelectedpersonelId = addZimmetRequest.personeller.Id;
            var Selectedpersonel = DbContext.Personeller.Find(SelectedpersonelId);

            //Kayıt kısmı
            var zimmet = new Zimmet()
            {
                Id = Guid.NewGuid(),
                MalzemeId = SelectedmalzemeId,
                PersonelId = SelectedpersonelId,
                VerilmeTarihi = addZimmetRequest.zimmet.VerilmeTarihi,
               

            };
            await DbContext.Zimmetler.AddAsync(zimmet);
            await DbContext.SaveChangesAsync();

            return RedirectToAction("ZimmetListeleme");
        }

		[HttpGet]
        [Authorize(Roles = "Admin,Depocu,Muhendis")]
        public async Task<IActionResult> ZimmetListeleme()
		{
			ZimmetListelemeViewModel model = new ZimmetListelemeViewModel();
			//Zimmetler tablosuna personel ve malzemeler tablosunun verilerini kullandırtığım kısım
			model.ZimmetPersonelMalzeme = DbContext.Zimmetler.Include(b => b.ZimmetEdilenKisi).ToList();
			model.ZimmetPersonelMalzeme = DbContext.Zimmetler.Include(b => b.ZimmetEdilenMalzeme).ToList();

			return View(model);


		}

		[HttpPost]
        [Authorize(Roles = "Admin,Depocu,Muhendis")]
        public async Task<IActionResult> Delete(Guid Id)
		{
			//silme kısmı
			var zimmet = DbContext.Zimmetler.Find(Id);
			if (zimmet != null)
			{
				DbContext.Zimmetler.Remove(zimmet);
				await DbContext.SaveChangesAsync();
				return RedirectToAction("ZimmetListeleme");
			}

			return RedirectToAction("ZimmetListeleme");
		}

	}
}
