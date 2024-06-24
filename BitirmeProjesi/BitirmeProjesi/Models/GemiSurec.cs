using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BitirmeProjesi.Models
{
	public class GemiSurec
	{

		public Guid Id { get; set; }

		[Required]
		[ForeignKey("GemiEnvanteri")]
		public Guid GemiEnvanteriId { get; set; }

		[Required]
		[ForeignKey("Personel")]
		public Guid PersonelId { get; set; }

		[Required]
		public string Durum { get; set; }
		[Required]
		public DateTime Tarih { get; set; }




		public Personel Personel { get; set; }

		public GemiEnvanteri GemiEnvanteri { get; set; }
	}
}
