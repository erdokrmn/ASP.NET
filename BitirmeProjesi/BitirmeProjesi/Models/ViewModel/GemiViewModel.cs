using System.ComponentModel.DataAnnotations;

namespace BitirmeProjesi.Models.ViewModel
{
    public class GemiViewModel
    {
        public Guid Id { get; set; }
        [Required]
        public string GemiAdı { get; set; }

        public string GemiTipi { get; set; }
        public int TahminiBitirmeSuresi { get; set; }
        [Required]
        public DateTime GemiyeBaslamaTarihi { get; set; }
    }
}
