using System.ComponentModel.DataAnnotations;

namespace BitirmeProjesi.Models
{
    public class Malzeme
    {
        public Guid Id { get; set; }
		[Required(ErrorMessage = "Boş bırakmayanız .")]
		public string MalzemeAdı { get; set; }

		[Required(ErrorMessage = "Boş bırakmayanız .")]
		public string? MalzemeTürü { get; set; }

        public string? MalzemeSkt { get; set; }
		[Required(ErrorMessage = "Boş bırakmayanız .")]
		public int MalzemeAdet { get; set; }

		[Required(ErrorMessage = "Boş bırakmayanız .")]
		public int MalzemeFiyatı { get; set; }

        public string? MalzemeKodu { get; set; }
        public DateTime MalzemeAlınısTarih { get; set; }
        public bool ÜrünDurumu { get; set; }

        public ICollection<Zimmet> ZimmetEdilenMalzemeler { get; set; }

    }
}
