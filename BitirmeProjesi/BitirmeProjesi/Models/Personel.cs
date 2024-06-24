using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace BitirmeProjesi.Models
{
	public class Personel
	{
		public Guid Id { get; set; }
		[Required]
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
		[Required]
		public string DoğumYılı { get; set; }
		[Required]
		public string EDevletŞifre { get; set; }
		public string CalıstıgıTershane { get; set; }
		[Required]
		public string AcilDurumdaUlaşılacakKişiNo { get; set; }

		public string Yetki {  get; set; }
        public int Maas { get; set; }

        [Required]
		public DateTime IseBaslamaTarihi { get; set; }

		[AllowNull]
		public DateTime IstenAyrılmaTarihi { get; set; }

		[Required]
		public bool CalısmaDurumu { get; set; }


		public virtual ICollection<Tevzi> Tevziler { get; set; }
        public virtual ICollection<Maas> Maaslar { get; set; }
        public virtual ICollection<GC> GCler { get; set; }
        public virtual ICollection<GemiSurec> GemiSurecleri { get; set; }
		public virtual ICollection<Zimmet> ZimmetEdilenPersoneller { get; set; }
        public virtual ICollection<FingerPrintData> FingerPrintDatas { get; set; }
    }
}
