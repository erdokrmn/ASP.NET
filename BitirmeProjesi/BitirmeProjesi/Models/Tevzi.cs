using BitirmeProjesi.Models;
using System.ComponentModel.DataAnnotations;

namespace BitirmeProjesiEkranlar.Models
{
    public class Tevzi
    {
        public Guid Id { get; set; }
        [Required]
        public DateTime TevziTarih { get; set; }
        [Required]
        public int CalısmaSaati { get; set; }
        [Required]
        public int MesaiSaati { get; set; }
        [Required]
        public bool Durum { get; set; }
        [Required]
        public Personel Personel { get; set; }
    }
}
