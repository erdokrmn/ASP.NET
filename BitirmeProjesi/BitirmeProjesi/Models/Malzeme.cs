using System.ComponentModel.DataAnnotations;

namespace BitirmeProjesiEkranlar.Models
{
    public class Malzeme
    {
        public Guid Id { get; set; }
        [Required]
        public string MalzemeAdı { get; set; }
        [Required]
        public string MalzemeTürü { get; set; }

        public int MalzemeSkt { get; set; }
        [Required]
        public int MalzemeAdet { get; set; }
        
        public int MalzemeFiyatı { get; set; }

        public string MalzemeKodu { get; set; }
        [Required]
        public DateTime MalzemeAlınısTarih { get; set; }
        public bool ÜrünDurumu { get; set; }

        public ICollection<Zimmet> ZimmetEdilenMalzemeler { get; set; }

    }
}
