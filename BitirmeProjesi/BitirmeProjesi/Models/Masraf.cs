using System.ComponentModel.DataAnnotations;

namespace BitirmeProjesiEkranlar.Models
{
    public class Masraf
    {
        public Guid Id { get; set; }
        [Required]
        public string MasrafAdı { get; set; }
        [Required]
        public string MasrafTipi { get; set; }
        [Required]
        public string MasrafTutarı { get; set; }
        [Required]
        public string MasrafTarihi { get; set; }
    }
}
