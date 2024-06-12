using System.Net.Sockets;
using System.Net;
using BitirmeProjesi.DataContext;
using Microsoft.EntityFrameworkCore;
using BitirmeProjesi.Models.ViewModel;

namespace BitirmeProjesi
{
	public class PuantajVeMaaş
	{
        private readonly BitirmeProjesiDbContext DbContext;

        public PuantajVeMaaş(BitirmeProjesiDbContext DbContext)
        {
            this.DbContext = DbContext;
        }

        public  async Task<List<PuantajViewModel>> HaftalikCalismaSaatleriniGetir(DateTime baslangicTarihi)
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

                return calismaSaatleri;
            
        }
    }
}
