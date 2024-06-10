using System.ComponentModel.DataAnnotations;

namespace BitirmeProjesi.Models.ViewModel
{
    public class RegisterViewModel
    {
        [Required]
        public string Username { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        public UserRoles Role { get; set; }
    }
    public enum UserRoles
    {
        Admin,
        AdminYardimcisi,
        Yetki1,
        Yetki2
    }
}
