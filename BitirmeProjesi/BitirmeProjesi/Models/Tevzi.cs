using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BitirmeProjesi.Models
{
    public class Tevzi
    {
        public Guid Id { get; set; }
       

        [Required]
        [ForeignKey("Personel")]
        public Guid PersonelId { get; set; }
		[Required]
        public DateTime TevziTarih { get; set; }
        [Required]
        public int CalısmaSaati { get; set; }
        [Required]
        public int MesaiSaati { get; set; }
        [Required]
        public bool Durum { get; set; }
        [Required]
        public virtual Personel Personel { get; set; }
    }
}
