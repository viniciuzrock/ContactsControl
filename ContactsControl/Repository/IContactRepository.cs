using ContactsControl.Models;

namespace ContactsControl.Repository
{
    public interface IContactRepository
    {
        bool DeleteContact(int id);
        ContactModel EditContact(ContactModel contato);
        ContactModel GetContact(int id);
        List<ContactModel> GetAllContacts();
        ContactModel AddContact(ContactModel contato);
    }
}
