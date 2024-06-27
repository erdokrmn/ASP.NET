using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace BitirmeProjesi.Models
{
    public class Gemi
    {
        public Guid Id { get; set; }

		[Required(ErrorMessage = "Boş Bırakmayınız.")]
		public string GemiAdı { get; set; }

		[Required(ErrorMessage = "Boş Bırakmayınız.")]
		public string GemiTipi { get; set; }
		[Required(ErrorMessage = "Boş Bırakmayınız.")]
		public string TershaneAdı { get; set; }
		[Required(ErrorMessage = "Boş Bırakmayınız.")]
		public int TahminiBitirmeSuresi { get; set; }
        [Required]
        public DateTime GemiyeBaslamaTarihi { get; set; }

        public ICollection<GemiEnvanteri> gemiEnvanterileri { get; set; }

    }
}
