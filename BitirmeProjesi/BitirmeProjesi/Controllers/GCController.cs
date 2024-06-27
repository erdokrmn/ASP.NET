using BitirmeProjesi.Models.ViewModel;
using BitirmeProjesi.Models;
using ExcelDataReader;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BitirmeProjesi.DataContext;
using System.Text.RegularExpressions;
using System.Text;
using Microsoft.AspNetCore.Authorization;
using GC = BitirmeProjesi.Models.GC;

namespace BitirmeProjesi.Controllers
{
    public class GCController : Controller
    {
        private readonly BitirmeProjesiDbContext DbContext;

        public GCController(BitirmeProjesiDbContext DbContext)
        {
            this.DbContext = DbContext;
        }

        [HttpGet]
        [Authorize(Roles = "Admin,Muhasebeci,Puantor")]
        public async Task<IActionResult> GCListeleme()
        {
            var gCs = await DbContext.GCs.ToListAsync();

            return View(gCs);


        }
		[HttpPost]
		[Authorize(Roles = "Admin,Muhasebeci,Puantor")]
		public async Task<IActionResult> Delete(Guid Id)
		{
			//silme kısmı
			var gc = DbContext.GCs.Find(Id);
			if (gc != null)
			{
				DbContext.GCs.Remove(gc);
				await DbContext.SaveChangesAsync();
				return RedirectToAction("GCListeleme");
			}

			return RedirectToAction("GCListeleme");
		}
		[Authorize(Roles = "Admin,Muhasebeci,Puantor")]
        public IActionResult GCManuelKayıt()
        {
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "Admin,Muhasebeci,Puantor")]
        public async Task<IActionResult> GCManuelKayıt(GCManuelViewModel addGCRequest)
        {
            
            if (!ModelState.IsValid)
            {
                // Masraflar property'sine ait doğrulama hatalarını kaldır
                ModelState.Remove("PersonelAd");
                ModelState.Remove("PersonelId");
                ModelState.Remove("AdSoyad");

                // Tekrar kontrol et
                if (!ModelState.IsValid)
                {
                    return View(addGCRequest);
                }
            }
            var personel = await DbContext.Personeller.FirstOrDefaultAsync(p => p.TcNo == addGCRequest.TcNo);

            if (personel == null)
            {
                ModelState.AddModelError("TCKimlikNo", "Girilen TC Kimlik Numarasına ait personel bulunamadı.");
                return View(addGCRequest);
            }
            
            //Kayıt kısmı
            var gc = new GC()
            {
                Id = Guid.NewGuid(),
                PersonelId= personel.Id,
                AdSoyad=(personel.Ad + " " + personel.Soyad),
                GS = addGCRequest.Tarih + addGCRequest.GS,
                CS = addGCRequest.Tarih + addGCRequest.CS,
                Tarih = addGCRequest.Tarih,

            };
            await DbContext.GCs.AddAsync(gc);
            await DbContext.SaveChangesAsync();

            return RedirectToAction("GCManuelKayıt");
        }

        [Authorize(Roles = "Admin,Muhasebeci,Puantor")]
        public IActionResult GCKayıt()
        {
            return View();
        }

        [Authorize(Roles = "Admin,Muhasebeci,Puantor")]
        [HttpPost]
        public async Task<ActionResult> UploadFile(IFormFile file, GemiEnvanteriViewModel viewModel)
        {

            var personeller = await DbContext.Personeller.ToListAsync();
            string advesoyad="";

            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
            if (file != null && file.Length > 0)
            {
                var uploadDirctory = $"{Directory.GetCurrentDirectory()}\\wwwroot\\Uploads";

                if (!Directory.Exists(uploadDirctory))
                {
                    Directory.CreateDirectory(uploadDirctory);
                }
                var filePath = Path.Combine(uploadDirctory, file.Name);
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }
                using (var stream = System.IO.File.Open(filePath, FileMode.Open, FileAccess.Read))
                {
                    using (var reader = ExcelReaderFactory.CreateReader(stream))
                    {
                        while (reader.Read())
                        {

                           
                                var adsoyad = reader.GetValue(0); // adsoyad sütununun index'i
                                if (adsoyad != null) /// gelen adsoyad sutununda boş değer olmasına karşın kontrol
                                {

                                    var rowData = new Models.GC();
                                    rowData.Id = Guid.NewGuid();
                                    foreach (var item in personeller)
                                    {
                                        advesoyad = item.Ad + " " + item.Soyad;
                                        if (NormalizeString(advesoyad)==NormalizeString(adsoyad.ToString()))
                                            rowData.PersonelId = item.Id;


                                    }
                                    for (int y = 0; y < reader.FieldCount; y++)
                                    {


                                        var propertyValue = reader.GetValue(y);

                                        SetProperty(rowData, y, propertyValue); // Her sütuna karşılık gelen özelliğe veriyi ata


                                    }

                                    if (rowData.PersonelId != Guid.Empty)
                                    {
                                    //Veritabanına kaydet
                                    DbContext.GCs.Add(rowData);
                                    DbContext.SaveChanges();
                                }
                                }
                                else
                                {
                                    continue;
                                }

                           
                        }
                    }


                }

            }
            return View("GCKayıt");
        }
        public static string NormalizeString(string input)
        {
            if (input == null)
                return null;

            // Unicode normalizasyonu
            string normalized = input.Normalize(NormalizationForm.FormD);

            // Kombine edilen karakterleri kaldırma
            normalized = Regex.Replace(normalized, @"\p{Mn}", "");

            // Tüm boşlukları kaldırma
            normalized = Regex.Replace(normalized, @"\s+", "");

            // Küçük harfe çevirme
            return normalized.ToLowerInvariant();
        }
        private void SetProperty(Models.GC model, int index, object value)
        {
            switch (index)
            {
                case 0:
                    model.AdSoyad = value.ToString();
                    break;
                case 1:
                    model.Tarih = Convert.ToDateTime(value);
                    break;
                case 2:
                    model.GS = Convert.ToDateTime(value);
                    break;
                case 3:
                    model.CS = Convert.ToDateTime(value);
                    break;
                    
                default:
                    break;
            }
        }
    }
}
