using System.ComponentModel.DataAnnotations;

namespace BitirmeProjesi.Models
{
    public class Firma
    {

        public Guid Id { get; set; }

        [Required]
        public string FirmaAdı { get; set; }

        public string TelofonNo { get; set; }

        public string İlgiliKisi { get; set; }

        public string Iban { get; set; }


        public virtual ICollection<Masraf> Masraflar { get; set; }
    }
}
