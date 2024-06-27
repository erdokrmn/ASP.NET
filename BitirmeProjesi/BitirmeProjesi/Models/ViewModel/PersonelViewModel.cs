using System.ComponentModel.DataAnnotations;

namespace BitirmeProjesi.Models.ViewModel
{
    public class PersonelViewModel
    {
		public Guid Id { get; set; }

        [Required(ErrorMessage = "Lütfen adını giriniz.")]
        public string Ad { get; set; }
        [Required(ErrorMessage = "Lütfen soyadını giriniz.")]
        public string Soyad { get; set; }

        [Required(ErrorMessage = "Tc Kimlik numarası gereklidir.")]
        [StringLength(11, MinimumLength = 11, ErrorMessage = "TC Kimlik  11 haneli olmalıdır.")]
        public string TcNo { get; set; }
        [Required(ErrorMessage = "Telefon numarası gereklidir.")]
        [StringLength(11, MinimumLength = 10, ErrorMessage = "Telefon numarası 10 veya 11 haneli olmalıdır.")]
        public string TelefonNo { get; set; }
        public string Yetki { get; set; }

        [Required(ErrorMessage = "Lütfen maaşı giriniz.")]
        public int Maas { get; set; }
        [Required(ErrorMessage = "Lütfen kangrubunu giriniz.")]
        public string KanGrubu { get; set; }

        [Required(ErrorMessage = "Lütfen doğum yerini giriniz.")]
        public string DoğumYeri { get; set; }
        [Required(ErrorMessage = "Lütfen il giriniz.")]
        public string Il { get; set; }
        [Required(ErrorMessage = "Lütfen ilçe giriniz.")]
        public string Ilce { get; set; }
        [Required(ErrorMessage = "Lütfen adres giriniz.")]
        public string Adres { get; set; }
        [Required]
        public bool Cinsiyet { get; set; }

        [Required(ErrorMessage = "Lütfen çalıştığı tershaneyi giriniz.")]
        public string CalıstıgıTershane { get; set; }
        [Required(ErrorMessage = "Lütfen doğum yılını giriniz.")]
        public string DoğumYılı { get; set; }
        [Required(ErrorMessage = "Lütfen e-devlet şifresini giriniz.")]
        public string EDevletŞifre { get; set; }
        [Required(ErrorMessage = "Lütfen acil durumda ulaşılacak kişinin numarasını giriniz.")]
        [StringLength(11, MinimumLength = 10, ErrorMessage = "Telefon numarası 10 veya 11 haneli olmalıdır.")]
        public string AcilDurumdaUlaşılacakKişiNo { get; set; }
        [Required]
        public DateTime IseBaslamaTarihi { get; set; }


        public DateTime IstenAyrılmaTarihi { get; set; }

        [Required]
        public bool CalısmaDurumu { get; set; }


    }
}
