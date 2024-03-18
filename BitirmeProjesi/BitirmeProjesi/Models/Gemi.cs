using System.ComponentModel.DataAnnotations;

namespace BitirmeProjesiEkranlar.Models
{
    public class Gemi
    {
        public Guid Id { get; set; }
        [Required]
        public string GemiAdı { get; set; }
        
        public string GemiTipi { get; set; }
        public int TahminiBitirmeSuresi { get; set; }
        [Required]
        public DateTime GemiyeBaslamaTarihi { get; set; }
        [Required]
        public ICollection<GemiEnvanteri> gemiEnvanterileri { get; set; }

    }
}
