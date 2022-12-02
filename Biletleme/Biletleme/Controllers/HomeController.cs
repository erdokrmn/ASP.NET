using Biletleme.Models;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using System.Diagnostics;

namespace Biletleme.Controllers
{
    public class HomeController : Controller
    {
       public Musteri musteriBilgi = new Musteri();
        private readonly ILogger<HomeController> _logger;

        public List<Musteri> listMusteriler = new List<Musteri>();
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public void accesDb()
        {
            //try
            //{
            //    string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Deneme;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            //    using (SqlConnection connection = new SqlConnection(connectionString))
            //    {
            //        connection.Open();
            //        string sql = "SELECET * FROM Musteriler";
            //        using (SqlCommand command = new SqlCommand(sql, connection))
            //        {
            //            using (SqlDataReader reader = command.ExecuteReader())
            //            {
            //                while (reader.Read())
            //                {
            //                    musteriBilgi.Id = reader.GetInt32(0);
            //                    musteriBilgi.Ad = reader.GetString(1);
            //                    musteriBilgi.Soyad = reader.GetString(2);
            //                    musteriBilgi.DoğumTarihi = reader.GetDateTime(3);
            //                    musteriBilgi.TelNo = reader.GetString(4);
            //                    musteriBilgi.EMail = reader.GetString(5);
            //                    musteriBilgi.KayıtTarihi = reader.GetDateTime(6);
            //                    musteriBilgi.Durum = reader.GetBoolean(7);

            //                    listMusteriler.Add(musteriBilgi);
            //                }
            //            }
            //        }
            //    }

            //}
            //catch (Exception ex)
            //{


            //}
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Create()
        {
            

            return View();
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}