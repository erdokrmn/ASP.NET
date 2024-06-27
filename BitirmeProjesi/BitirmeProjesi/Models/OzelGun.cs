using System.ComponentModel.DataAnnotations;

namespace BitirmeProjesi.Models
{
    public class OzelGun
    {
        public Guid Id { get; set; }

       
        [Required(ErrorMessage = "Resmi Tatil adı gereklidir.")]
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
