using System.ComponentModel.DataAnnotations;

namespace BitirmeProjesi.Models
{
    public class GemiSureci
    {
        public Guid Id { get; set; }

       
        public DateTime SürecTarihi { get; set; }

        [Required]
        public Personel CalısanPersoneller { get; set; }
        public GemiEnvanteri ParcaAdı { get; set; }
    }
}
