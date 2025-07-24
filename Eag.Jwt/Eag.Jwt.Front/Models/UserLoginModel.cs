using System.ComponentModel.DataAnnotations;

namespace Eag.Jwt.Front.Models
{
    public class UserLoginModel
    {
        [Required(ErrorMessage = "Kullanıcı adı zorunludur")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Şifre zorunludur")]
        public string Password { get; set; }
    }
}
