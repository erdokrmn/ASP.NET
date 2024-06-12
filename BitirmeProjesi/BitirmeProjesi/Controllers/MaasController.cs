using BitirmeProjesi.Models.ViewModel;
using BitirmeProjesi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BitirmeProjesi.DataContext;

namespace BitirmeProjesi.Controllers
{
	public class MaasController : Controller
	{
        private readonly BitirmeProjesiDbContext DbContext;

        public MaasController(BitirmeProjesiDbContext DbContext)
        {
            this.DbContext = DbContext;
        }
        public IActionResult Puantaj()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Puantaj(DateTime baslangicTarihi)
        {
            var zamanlamalar = await DbContext.GCs
                      .Where(z => z.GS >= baslangicTarihi)
                      .ToListAsync();

            var calismaSaatleri = zamanlamalar
                .GroupBy(z => z.AdSoyad)
                .Select(g => new PuantajViewModel
                {
                    AdSoyad = g.Key,
                    Hafta1 = g.Where(z => z.GS < baslangicTarihi.AddDays(7)).Sum(z => (z.CS - z.GS).TotalHours),
                    Hafta2 = g.Where(z => z.GS >= baslangicTarihi.AddDays(7) && z.GS < baslangicTarihi.AddDays(14)).Sum(z => (z.CS - z.GS).TotalHours),
                    Hafta3 = g.Where(z => z.GS >= baslangicTarihi.AddDays(14) && z.GS < baslangicTarihi.AddDays(21)).Sum(z => (z.CS - z.GS).TotalHours),
                    Hafta4 = g.Where(z => z.GS >= baslangicTarihi.AddDays(21) && z.GS < baslangicTarihi.AddDays(28)).Sum(z => (z.CS - z.GS).TotalHours)
                })
                .ToList();

            return View(calismaSaatleri);



        }
    }
}
