using System.ComponentModel.DataAnnotations;

namespace ContactsControl.Models
{
    public class ContactModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Digite o nome do contato.")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Digite o Email do contato.")]
        [EmailAddress(ErrorMessage ="O e-mail informado não é valido.")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Digite o Celular do contato.")]
        [Phone(ErrorMessage ="O celular informado não é válido")]
        public string Celular{ get; set; }
    }
}
