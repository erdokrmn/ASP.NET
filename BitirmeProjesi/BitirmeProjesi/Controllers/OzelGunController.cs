using BitirmeProjesi.DataContext;
using BitirmeProjesi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BitirmeProjesi.Controllers
{
    public class OzelGunController : Controller
    {
        private readonly BitirmeProjesiDbContext DbContext;

        public OzelGunController(BitirmeProjesiDbContext DbContext)
        {
            this.DbContext = DbContext;
        }

        [Authorize(Roles = "Admin,Muhasebeci,Puantor")]
        public IActionResult OzelGunKayıt()
        {
            return View();
        }

        [HttpGet]
        [Authorize(Roles = "Admin,Muhasebeci,Puantor")]
        public async Task<IActionResult> OzelGunListeleme()
        {
            var ozelgunler = await DbContext.OzelGunler.ToListAsync();

            return View(ozelgunler);


        }

        [HttpPost]
        [Authorize(Roles = "Admin,Muhasebeci,Puantor")]
        public async Task<IActionResult> OzelGunKayıt(OzelGun addOzelGunRequest)
        {
            //Kayıt kısmı
            var ozelgun = new OzelGun()
            {
                Id = Guid.NewGuid(),
                Name = addOzelGunRequest.Name,
                StartDate = addOzelGunRequest.StartDate,
                EndDate = addOzelGunRequest.EndDate,

            };
            await DbContext.OzelGunler.AddAsync(ozelgun);
            await DbContext.SaveChangesAsync();

            return RedirectToAction("OzelGunListeleme");
        }

        [HttpGet]
        [Authorize(Roles = "Admin,Muhasebeci,Puantor")]
        public async Task<IActionResult> OzelGunDuzenleme(Guid id)
        {
            //Güncelleme kısmına seçtiğimiz veriyi aktardığımız kısım
            var ozelgunler = await DbContext.OzelGunler.FirstOrDefaultAsync(x => x.Id == id);
            if (ozelgunler != null)
            {
                var viewModel = new OzelGun()
                {
                    Id = ozelgunler.Id,
                    Name = ozelgunler.Name,

                    StartDate = ozelgunler.StartDate,
                    EndDate = ozelgunler.EndDate,

                };
                return await Task.Run(() => View("OzelGunDuzenleme", viewModel));
            }
            return RedirectToAction("OzelGunListeleme");
        }

        [HttpPost]
        [Authorize(Roles = "Admin,Muhasebeci,Puantor")]
        public async Task<IActionResult> Delete(OzelGun updateGelirViewModel)
        {
            //silme kısmı
            var ozel = DbContext.OzelGunler.Find(updateGelirViewModel.Id);
            if (ozel != null)
            {
                DbContext.OzelGunler.Remove(ozel);
                await DbContext.SaveChangesAsync();
                return RedirectToAction("OzelGunListeleme");
            }

            return RedirectToAction("OzelGunListeleme");
        }

        [HttpPost]
        [Authorize(Roles = "Admin,Muhasebeci,Puantor")]
        public async Task<IActionResult> OzelGunDuzenleme(OzelGun updateOzelGun)
        {
            //Düzenleme yapılan kısım
            var ozelgun = DbContext.OzelGunler.Find(updateOzelGun.Id);
            if (ozelgun != null)
            {
                ozelgun.Name = updateOzelGun.Name;
                ozelgun.StartDate = updateOzelGun.StartDate;
                ozelgun.EndDate = updateOzelGun.EndDate;


                await DbContext.SaveChangesAsync();

            }
            return RedirectToAction("OzelGunListeleme");


        }
    }
}
