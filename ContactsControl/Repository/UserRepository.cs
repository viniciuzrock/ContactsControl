using ContactsControl.Data;
using ContactsControl.Migrations;
using ContactsControl.Models;

namespace ContactsControl.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly DataBaseContext _bancoContext;
        public UserRepository(DataBaseContext bancoContext) 
        {
            _bancoContext = bancoContext;
        }
        public UserModel GetUserByLogin(string login)
        {            
            return _bancoContext.Usuarios.FirstOrDefault(x => x.Login.ToLower() == login.ToLower());
        }

        public bool DeleteUser(int id)
        {
            Console.WriteLine("VERIFICA O ID:" + id);
            UserModel userToDelete = GetUser(id);
            if (userToDelete == null)
            {
                throw new Exception("Houve um erro na exclusão do contato.");
            }
            Console.WriteLine("Removeu ID" + id);
            _bancoContext.Usuarios.Remove(userToDelete);
            _bancoContext.SaveChanges();
            return true;
        }

        public UserModel EditUser(UserModel user)
        {
            UserModel userToEdit = GetUser(user.Id);

            if (userToEdit == null)
            {
                throw new Exception("Houve um erro na atualização do contato.");
            }

            userToEdit.Nome = user.Nome;
            userToEdit.Email = user.Email;
            userToEdit.Login = user.Login;
            userToEdit.Perfil = user.Perfil;
            userToEdit.DataAtualizacao = DateTime.Now;

            _bancoContext.Usuarios.Update(userToEdit);
            _bancoContext.SaveChanges();
            return userToEdit;
        }

        public UserModel GetUser(int id)
        {
            return _bancoContext.Usuarios.FirstOrDefault(user => user.Id == id);
        }

        public List<UserModel> GetAllUsers() 
        {
            return _bancoContext.Usuarios.ToList();//select all
        }

        public UserModel AddUser(UserModel user)
        {         
            user.DataCadastro = DateTime.Now;
            _bancoContext.Usuarios.Add(user);
            _bancoContext.SaveChanges();
            return user;
        }
    }
}
