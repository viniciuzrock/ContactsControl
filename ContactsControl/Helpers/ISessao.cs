using ContactsControl.Models;

namespace ContactsControl.Helpers
{
    public interface ISessao
    {
        void CreateISessaoUser(UserModel user);
        void RemoveISessaoUser();
        UserModel GetISessaoUser();
    }
}
