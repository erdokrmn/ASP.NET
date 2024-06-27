using System.ComponentModel.DataAnnotations;

namespace BitirmeProjesi.Models.ViewModel
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Kullanıcı adı gereklidir.")]
        [StringLength(20, MinimumLength = 4, ErrorMessage = "Kullanıcı adı en az 4 en fazla 20 karakter olabilir.")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Şifre gereklidir.")]
        [StringLength(20, MinimumLength = 8, ErrorMessage = "Şifre en az 8 ve en fazla 20 karakter olmalıdır.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        public UserRoles Role { get; set; }
    }
    public enum UserRoles
    {
        Admin,
        Muhasebeci,
        Depocu,
        Muhendis,
        Puantor,
    }
}
