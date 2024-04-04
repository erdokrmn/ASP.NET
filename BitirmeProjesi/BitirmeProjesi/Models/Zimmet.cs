using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BitirmeProjesi.Models
{
    public class Zimmet
    {
        public Guid Id { get; set; }

        [Required]
        public DateTime VerilmeTarihi { get; set; }
        [Required]
        [ForeignKey("Personel")]
        public Guid PersonelId { get; set; }
		[Required]
		[ForeignKey("Malzeme")]
		public Guid MalzemeId { get; set; }

		[Required]
        virtual public Personel ZimmetEdilenKisi { get; set; }
        [Required]
        virtual public Malzeme ZimmetEdilenMalzeme { get; set; }
    }
}
