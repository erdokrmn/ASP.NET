using System.ComponentModel.DataAnnotations;

namespace BitirmeProjesi.Models.ViewModel
{
    public class UpdatePersonelViewModel
    {
        public Guid Id { get; set; }
        public string Ad { get; set; }
        [Required]
        public string Soyad { get; set; }
        [Required]
        public string TcNo { get; set; }
        [Required]
        public string TelefonNo { get; set; }
        [Required]
        public string KanGrubu { get; set; }
        [Required]
        public string DoğumYeri { get; set; }
        [Required]
        public string Il { get; set; }
        [Required]
        public string Ilce { get; set; }
        [Required]
        public string Adres { get; set; }
        [Required]
        public bool Cinsiyet { get; set; }
        public string EMail { get; set; }
        [Required]
        public string DoğumYılı { get; set; }
        [Required]
        public string EDevletŞifre { get; set; }
        [Required]
        public string AcilDurumdaUlaşılacakKişiNo { get; set; }
        [Required]
        public DateTime IseBaslamaTarihi { get; set; }


        public DateTime IstenAyrılmaTarihi { get; set; }

        [Required]
        public bool CalısmaDurumu { get; set; }

    }
}
