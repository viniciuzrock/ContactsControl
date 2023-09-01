using System.ComponentModel.DataAnnotations;

namespace ContactsControl.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage ="Informe o login do usuário.")]
        public string Login{ get; set; }
        [Required(ErrorMessage = "Informe a senha do usuário.")]
        public string Password { get; set; }
    }
}
