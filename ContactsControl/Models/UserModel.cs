using ContactsControl.Enums;

namespace ContactsControl.Models
{
    public class UserModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Login { get; set; }
        public string Senha{ get; set; }
        public string Email { get; set; }
        public ProfileEnum Perfil { get; set; }
        public DateTime DataCadastro { get; set; }
        public DateTime? DataAtualizacao{ get; set; }
    }
}
