using System.ComponentModel.DataAnnotations;


namespace BitirmeProjesi.Models
{
    public class Masraf
    {
        public Guid Id { get; set; }
        [Required]
        public string MasrafAdı { get; set; }
        
        public string? MasrafTipi { get; set; }
        [Required]
        public int MasrafTutarı { get; set; }
        [Required]
        public DateTime MasrafTarihi { get; set; }
    }
}
