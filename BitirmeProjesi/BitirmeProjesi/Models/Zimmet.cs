using System.ComponentModel.DataAnnotations;

namespace BitirmeProjesiEkranlar.Models
{
    public class Zimmet
    {
        public Guid Id { get; set; }

        [Required]
        public DateTime VerilmeTarihi { get; set; }
        public string MalzemeSkt { get; set; }
        [Required]
        public Personel ZimmetEdilenKisi { get; set; }
        [Required]
        public Malzeme ZimmetEdilenMalzeme { get; set; }
    }
}
