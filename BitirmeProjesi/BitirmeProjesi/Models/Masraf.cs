using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace BitirmeProjesi.Models
{
    public class Masraf
    {
        public Guid Id { get; set; }

        [Required]
        [ForeignKey("Firma")]
        public Guid FirmaId { get; set; }

        [Required]
        public string MasrafAdı { get; set; }
        
        public string? MasrafTipi { get; set; }
        [Required]
        public int MasrafTutarı { get; set; }
        [Required]
        public DateTime ÖdemeTarihi { get; set; }

        public DateTime? ÖdenenTarih { get; set; }

        public virtual Firma Firma { get; set; }
    }
}
