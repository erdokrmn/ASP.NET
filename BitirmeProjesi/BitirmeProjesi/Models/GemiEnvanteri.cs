using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BitirmeProjesi.Models
{
    public class GemiEnvanteri
    {
        public Guid Id { get; set; }

		[Required]
		[ForeignKey("Gemi")]
		public Guid GemiId { get; set; }
		
		[Required]
        public string ParcaAdı { get; set; }
        [Required]
        public int ParcaMiktarı { get; set; }
        [Required]
        public string Zone { get; set; }
        [Required]
        public string Location { get; set; }
		




        [Required]
        public Gemi GemiAdı { get; set; }

		public virtual ICollection<GemiSurec> GemiSurecleri { get; set; }

	}
}
