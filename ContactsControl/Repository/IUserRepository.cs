using ContactsControl.Models;

namespace ContactsControl.Repository
{
    public interface IUserRepository
    {
        UserModel GetUserByLogin(string login);
        bool DeleteUser(int id);
        UserModel EditUser(UserModel user);
        UserModel GetUser(int id);
        List<UserModel> GetAllUsers();
        UserModel AddUser(UserModel user);
    }
}
