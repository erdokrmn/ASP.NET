using System.ComponentModel.DataAnnotations;

namespace BitirmeProjesi.Models.ViewModel
{
	public class MasrafViewModel
	{
        [Required(ErrorMessage = "Boş alanları doldurunuz.")]
        public Masraf masraflar { get; set; }

		public Firma firmalar { get; set; }

		public List<Masraf> MasrafFirma { get; set; }

	}
}
