using System.ComponentModel.DataAnnotations;

namespace BitirmeProjesi.Models
{
    public class Firma
    {

        public Guid Id { get; set; }

        [Required(ErrorMessage = "Firma Adı gereklidir.")]
        public string FirmaAdı { get; set; }

        [Required(ErrorMessage = "Telefon numarası gereklidir.")]
        [StringLength(11, MinimumLength = 10, ErrorMessage = "Telefon numarası 10 veya 11 haneli olmalıdır.")]
        public string TelofonNo { get; set; }

        [Required(ErrorMessage = "İlgili Kişi Adı gereklidir.")]
        public string İlgiliKisi { get; set; }

        [Required(ErrorMessage = "Iban gereklidir.")]
        public string Iban { get; set; }


        public virtual ICollection<Masraf> Masraflar { get; set; }
    }
}
