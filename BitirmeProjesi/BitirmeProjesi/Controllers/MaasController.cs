using BitirmeProjesi.Models.ViewModel;
using BitirmeProjesi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BitirmeProjesi.DataContext;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Authorization;

namespace BitirmeProjesi.Controllers
{
	public class MaasController : Controller
	{
        private readonly BitirmeProjesiDbContext DbContext;

        public MaasController(BitirmeProjesiDbContext DbContext)
        {
            this.DbContext = DbContext;
        }

        [Authorize(Roles = "Admin,Muhasebeci")]
        public IActionResult Puantaj()
        {
            return View();
        }

		[HttpGet]
        [Authorize(Roles = "Admin,Muhasebeci")]
        public async Task<IActionResult> MaasListeleme()
		{
			MaasViewModel model = new MaasViewModel();
			//Tevziler tablosuna personel tablosunun verilerini kullandırtığım kısım
			model.MaasPersonel = DbContext.Maaslar.Include(b => b.Personel).ToList();

			return View(model);


		}

		[HttpGet]
        [Authorize(Roles = "Admin,Muhasebeci")]
        public async Task<IActionResult> MaasDuzenleme(Guid id)
		{
			List<SelectListItem> personeller = (from x in DbContext.Personeller.ToList()
											 select new SelectListItem
											 {
												 Text = x.Ad,
												 Value = x.Id.ToString()
											 }).ToList();
			ViewBag.Personeller = personeller;
			//Güncelleme kısmına seçtiğimiz veriyi aktardığımız kısım
			var maas = await DbContext.Maaslar.FirstOrDefaultAsync(x => x.Id == id);
			if (maas != null)
			{
				var viewModel = new Maas()
				{
					Id = maas.Id,
					MaasTutarı = maas.MaasTutarı,
					NormalMaas = maas.NormalMaas,
					MesaiMaasi = maas.MesaiMaasi,
					DegerMaasi = maas.DegerMaasi,
					OzelGunMaasi = maas.OzelGunMaasi,
                    MaasTarihi = maas.MaasTarihi,
                    PersonelId = maas.PersonelId,

				};
				return await Task.Run(() => View("MaasDuzenleme", viewModel));
			}
			return RedirectToAction("MaasListeleme");
		}

		[HttpPost]
        [Authorize(Roles = "Admin,Muhasebeci")]
        public async Task<IActionResult> Delete(Maas deleteViewModel)
		{
			//silme kısmı
			var maas = DbContext.Maaslar.Find(deleteViewModel.Id);
			if (maas != null)
			{
				DbContext.Maaslar.Remove(maas);
				await DbContext.SaveChangesAsync();
				return RedirectToAction("MaasListeleme");
			}

			return RedirectToAction("MaasListeleme");
		}

		[HttpPost]
        [Authorize(Roles = "Admin,Muhasebeci")]
        public async Task<IActionResult> MaasDuzenleme(Maas updateMaasViewModel)
		{
			var SelectedFirmaId = updateMaasViewModel.PersonelId;

			//Düzenleme yapılan kısım
			var maas = DbContext.Maaslar.Find(updateMaasViewModel.Id);
			if (maas != null)
			{
                maas.MaasTutarı = updateMaasViewModel.MaasTutarı;
                maas.NormalMaas = updateMaasViewModel.NormalMaas;
                maas.MesaiMaasi = updateMaasViewModel.MesaiMaasi;
                maas.DegerMaasi = updateMaasViewModel.DegerMaasi;
                maas.OzelGunMaasi = updateMaasViewModel.OzelGunMaasi;
                maas.MaasTarihi = updateMaasViewModel.MaasTarihi;
                maas.PersonelId = SelectedFirmaId;


				await DbContext.SaveChangesAsync();

			}
			return RedirectToAction("MaasListeleme");


		}


		[HttpPost]
        [Authorize(Roles = "Admin,Muhasebeci")]
        public async Task<IActionResult> Puantaj(DateTime baslangicTarihi)
        {
            var zamanlamalar = await DbContext.GCs
                .Where(z => z.GS >= baslangicTarihi)
                .ToListAsync();

            var calismaSaatleri = zamanlamalar
                .Select(z => new
                {
                    AdSoyad = z.AdSoyad,
                    GS = AdjustStartTime(z.GS),
                    CS = AdjustEndTime(z.CS)
                })
                .GroupBy(z => z.AdSoyad)
                .Select(g => new PuantajViewModel
                {
                    AdSoyad = g.Key,
                    Hafta1 = (int)g.Where(z => z.GS < baslangicTarihi.AddDays(7)).Sum(z => (z.CS - z.GS).TotalHours),
                    Hafta2 = (int)g.Where(z => z.GS >= baslangicTarihi.AddDays(7) && z.GS < baslangicTarihi.AddDays(14)).Sum(z => (z.CS - z.GS).TotalHours),
                    Hafta3 = (int)g.Where(z => z.GS >= baslangicTarihi.AddDays(14) && z.GS < baslangicTarihi.AddDays(21)).Sum(z => (z.CS - z.GS).TotalHours),
                    Hafta4 = (int)g.Where(z => z.GS >= baslangicTarihi.AddDays(21) && z.GS < baslangicTarihi.AddDays(28)).Sum(z => (z.CS - z.GS).TotalHours),
                    OzelGunCalismaSaati = OzelGunCalismaSaatleriniHesapla(g.Key, baslangicTarihi, baslangicTarihi.AddDays(28)) // Özel gün çalışma saatlerini hesapla
                })
                .ToList();

            return View(calismaSaatleri);
        }

        [HttpPost]
        [Authorize(Roles = "Admin,Muhasebeci")]
        public async Task<IActionResult> MaasHesapla(List<PuantajViewModel> model)
        {
            foreach (var item in model)
            {
                if (!string.IsNullOrEmpty(item.AdSoyad))
                {
                    // Personelin toplam çalışma saatlerini haftalık olarak hesapla
                    var hafta1CalismaSaati = item.Hafta1 > 45 ? 45 : item.Hafta1;
                    var hafta2CalismaSaati = item.Hafta2 > 45 ? 45 : item.Hafta2;
                    var hafta3CalismaSaati = item.Hafta3 > 45 ? 45 : item.Hafta3;
                    var hafta4CalismaSaati = item.Hafta4 > 45 ? 45 : item.Hafta4;

                    // Toplam çalışma saatlerini hesapla
                    var toplamCalismaSaati = hafta1CalismaSaati + hafta2CalismaSaati + hafta3CalismaSaati + hafta4CalismaSaati;

                    // Mesai saatlerini haftalık olarak hesapla
                    var mesaiHafta1 = item.Hafta1 > 45 ? item.Hafta1 - 45 : 0;
                    var mesaiHafta2 = item.Hafta2 > 45 ? item.Hafta2 - 45 : 0;
                    var mesaiHafta3 = item.Hafta3 > 45 ? item.Hafta3 - 45 : 0;
                    var mesaiHafta4 = item.Hafta4 > 45 ? item.Hafta4 - 45 : 0;
                    var toplammesai = (mesaiHafta1 + mesaiHafta2 + mesaiHafta3 + mesaiHafta4);

                    // Personelin maaş bilgisini al
                    var personel = await DbContext.Personeller
                        .FirstOrDefaultAsync(p => (p.Ad + " " + p.Soyad) == item.AdSoyad);

                    if (personel != null)
                    {
                        // Maaş tarihini haftaların bulunduğu ay ve yıl bilgisi olarak ayarla
                        var maasTarihi = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);

                        // Aynı tarihte aynı kişinin maaşı zaten hesaplanmış mı kontrol et
                        var mevcutKayit = await DbContext.Maaslar
                            .FirstOrDefaultAsync(m => m.PersonelId == personel.Id && m.MaasTarihi == maasTarihi);

                        if (mevcutKayit != null)
                        {
                            // Aynı tarihte aynı kişinin maaşı zaten hesaplanmış, kullanıcıya bilgilendirme mesajı ver
                            TempData["Message"] = $"Bu tarihte ({maasTarihi:yyyy-MM}) {item.AdSoyad} için maaş zaten hesaplanmıştır.";
                            continue;
                        }
                        else
                        {
                            // Saatlik ücreti hesapla
                            var saatlikUcret = personel.Maas / 225;

                            // Özel gün saatlerini toplam çalışma saatlerinden çıkar
                            var kalanCalismaSaati = toplamCalismaSaati - item.OzelGunCalismaSaati;

                            // Normal çalışma maaşını hesapla (Kalan çalışma saatleri * saatlik ücret)
                            var normalMaas = kalanCalismaSaati * saatlikUcret;

                            // Mesai ücretini hesapla (Mesai saatleri * saatlik ücret * 1.5)
                            var mesaiMaasi = toplammesai * saatlikUcret * 1.5;

                            // Değer kısmı maaşını hesapla (Değer * saatlik ücret)
                            var degerMaasi = item.Deger * saatlikUcret * 7.5;

                            // Özel çalışma maaşını hesapla (Özel gün sayısı * saatlik ücret * 2)
                            var ozelGunMaasi = item.OzelGunCalismaSaati * saatlikUcret * 2;

                            // Toplam maaşı hesapla
                            var toplamMaas = normalMaas + mesaiMaasi + degerMaasi + ozelGunMaasi;

                            // Maaş kaydını oluştur
                            var maasKaydi = new Maas
                            {
                                Id = Guid.NewGuid(),
                                PersonelId = personel.Id,
                                MaasTarihi = maasTarihi,
                                NormalMaas = normalMaas,
                                MesaiMaasi = (int)mesaiMaasi,
                                DegerMaasi = (int)degerMaasi,
                                OzelGunMaasi = (int)ozelGunMaasi,
                                MaasTutarı = (int)toplamMaas
                            };

                            DbContext.Maaslar.Add(maasKaydi);
                        } 
                      
                    }
                }
            }

            await DbContext.SaveChangesAsync();
            return RedirectToAction("Puantaj");
        }


        private DateTime AdjustStartTime(DateTime startTime)
        {
            // Eğer başlangıç saati 08:00'dan küçükse, 08:00 olarak ayarla
            if (startTime.TimeOfDay < new TimeSpan(8, 0, 0))
            {
                return new DateTime(startTime.Year, startTime.Month, startTime.Day, 8, 0, 0);
            }

            return startTime;
        }

        private DateTime AdjustEndTime(DateTime endTime)
        {
            // Eğer bitiş saati 16:50-17:30 arasındaysa, 17:00 olarak ayarla
            if (endTime.TimeOfDay > new TimeSpan(16, 50, 0) && endTime.TimeOfDay <= new TimeSpan(17, 30, 0))
            {
                return new DateTime(endTime.Year, endTime.Month, endTime.Day, 17, 0, 0);
            }

            return endTime;
        }

        

        private int OzelGunCalismaSaatleriniHesapla(string adSoyad, DateTime baslangicTarihi, DateTime bitisTarihi)
        {
            var ozelGunler = DbContext.OzelGunler
                .Where(sd => (sd.StartDate >= baslangicTarihi && sd.StartDate <= bitisTarihi) ||
                             (sd.EndDate >= baslangicTarihi && sd.EndDate <= bitisTarihi) ||
                             (sd.StartDate <= baslangicTarihi && sd.EndDate >= bitisTarihi))
                .ToList();

            int ozelGunCalismaSaati = 0;

            foreach (var ozelGun in ozelGunler)
            {
                var ozelGunBaslangic = ozelGun.StartDate < baslangicTarihi ? baslangicTarihi : ozelGun.StartDate;
                var ozelGunBitis = ozelGun.EndDate > bitisTarihi ? bitisTarihi : ozelGun.EndDate;

                // Her özel gün için çalışma saatlerini hesapla
                var calismaSaatleri = DbContext.GCs
                    .Where(z => z.AdSoyad == adSoyad &&
                                z.GS >= ozelGunBaslangic && z.GS <= ozelGunBitis)
                    .ToList();

                foreach (var calismaSaati in calismaSaatleri)
                {
                    ozelGunCalismaSaati += (int)(calismaSaati.CS - calismaSaati.GS).TotalHours;
                }
            }

            return ozelGunCalismaSaati;
        }

    }
}
