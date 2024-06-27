using System.ComponentModel.DataAnnotations;

namespace BitirmeProjesi.Models
{
    public class Gelir
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Boş alanları doldurunuz.")]
        public string FaturaKesilenAd { get; set; }

        [Required(ErrorMessage = "Boş alanları doldurunuz.")]
        public int Miktar { get; set; }

        [Required(ErrorMessage = "Boş alanları doldurunuz.")]
        public int Kesinti { get; set; }

        public DateTime FaturaTarihi { get; set; }

        public DateTime? ÖdenmeTarihi { get; set; }
    }
}
