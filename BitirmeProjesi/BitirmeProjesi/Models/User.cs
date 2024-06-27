using System.ComponentModel.DataAnnotations;

namespace BitirmeProjesi.Models
{
    public class User
    {
       
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Kullanıcı adı gereklidir.")]
        [StringLength(20,MinimumLength =4, ErrorMessage = "Kullanıcı adı en fazla 20 karakter olabilir.")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Şifre gereklidir.")]
        [StringLength(20, MinimumLength = 8, ErrorMessage = "Şifre en az 8 ve en fazla 20 karakter olmalıdır.")]
        public string Password { get; set; }
        public string Role { get; set; }
        public bool IsLoggedIn { get; set; }
    }
}
