using BitirmeProjesi.DataContext;
using BitirmeProjesi.Models;
using BitirmeProjesi.Models.ViewModel;
using ExcelDataReader;
using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using OfficeOpenXml;
using System.Data;
using System.Data.OleDb;
using System.Web;

namespace BitirmeProjesi.Controllers
{
    public class GemiEnvanteriController : Controller
    {
        private readonly BitirmeProjesiDbContext DbContext;

        public GemiEnvanteriController(BitirmeProjesiDbContext DbContext)
        {
            this.DbContext = DbContext;
        }
        public IActionResult GemiEnvanteriKayıt()
        {
            GemiEnvanteriViewModel model = new GemiEnvanteriViewModel();
            //Zimmetler tablosuna personel ve malzemeler tablosunun verilerini kullandırtığım kısım
            //model.GemiEnvanteriGemi = DbContext.GemiEnvanterleri.Include(b => b.GemiAdı).ToList();

            List<SelectListItem> gemiler = (from x in DbContext.Gemiler.ToList()
                                               select new SelectListItem
                                               {
                                                   Text = x.GemiAdı,
                                                   Value = x.Id.ToString()
                                               }).ToList();
            ViewBag.Gemiler = gemiler;
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> UploadFile(IFormFile file,GemiEnvanteriViewModel viewModel)
        {
            var SelectedgemiId = viewModel.gemiler.Id;
            var Selectedgemi = DbContext.Gemiler.Find(SelectedgemiId);


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
                            var qtyValue = reader.GetValue(1); // Qty sütununun index'i
                            if (qtyValue != null && int.TryParse(qtyValue.ToString(), out int qty))
                            {
                                // Qty sütunu sayı ile doluysa satırı işle
                                var rowData = new GemiEnvanteri();
                                // Gemi Id'sini ekle
                                rowData.Id = new Guid();
                                rowData.GemiId = SelectedgemiId;
                                // Her satır için bir GemiEnvanteri nesnesi oluştur
                                for (int i = 0; i < reader.FieldCount; i++)
                                {
                                    // Her sütunun değerini GemiEnvanteri nesnesine atayarak veri aktar
                                    var propertyValue = reader.GetValue(i);
                                    SetProperty(rowData, i, propertyValue); // Her sütuna karşılık gelen özelliğe veriyi ata
                                }

                               

                                // Veritabanına kaydet
                                DbContext.GemiEnvanterleri.Add(rowData);
                                DbContext.SaveChanges();

                            }
                            else
                            {
                                continue;
                            }
                        }
                    }

                   
                }
                
            }
            return View("GemiEnvanteriListeleme");
        }
        private void SetProperty(GemiEnvanteri model, int index, object value)
        {
            switch (index)
            {
                case 0:
                    model.ParcaAdı = Convert.ToString(value);
                    break;
                case 1:
                    model.ParcaMiktarı = Convert.ToInt32(value);
                    break;
                case 2:
                    model.Zone = Convert.ToString(value);
                    break;
                case 3:
                    model.Location = Convert.ToString(value);
                    break;  
                default:
                    break;
            }
        }
    }
}