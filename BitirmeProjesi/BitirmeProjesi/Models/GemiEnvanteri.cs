using System.ComponentModel.DataAnnotations;

namespace BitirmeProjesi.Models
{
    public class GemiEnvanteri
    {
        public Guid Id { get; set; }
        [Required]
        public string Sfı { get; set; }
        [Required]
        public string ParcaAdı { get; set; }
        [Required]
        public int ParcaMiktarı { get; set; }
        [Required]
        public string Zone { get; set; }
        [Required]
        public string Location { get; set; }

        public ICollection<GemiSureci> Parca { get; set; }
        [Required]
        public Gemi GemiAdı { get; set; }



    }
}
