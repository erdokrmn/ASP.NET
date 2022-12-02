namespace Biletleme.Models
{
    public class AddMusteriViewModel
    {
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public DateTime DoğumTarihi { get; set; }
        public string TelNo { get; set; }
        public string EMail { get; set; }
        public DateTime KayıtTarihi { get; set; }
        public bool Durum { get; set; }
    }
}
