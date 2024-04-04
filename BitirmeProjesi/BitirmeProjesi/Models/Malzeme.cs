using System.ComponentModel.DataAnnotations;

namespace BitirmeProjesi.Models
{
    public class Malzeme
    {
        public Guid Id { get; set; }
        [Required]
        public string MalzemeAdı { get; set; }
        
        public string? MalzemeTürü { get; set; }

        public string? MalzemeSkt { get; set; }
        [Required]
        public int MalzemeAdet { get; set; }

		[Required]
		public int MalzemeFiyatı { get; set; }

        public string? MalzemeKodu { get; set; }
        [Required]
        public DateTime MalzemeAlınısTarih { get; set; }
        public bool ÜrünDurumu { get; set; }

        public ICollection<Zimmet> ZimmetEdilenMalzemeler { get; set; }

    }
}
