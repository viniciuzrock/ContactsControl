using ContactsControl.Data;
using ContactsControl.Migrations;
using ContactsControl.Models;

namespace ContactsControl.Repository
{
    public class ContactRepository : IContactRepository
    {
        private readonly DataBaseContext _bancoContext;
        public ContactRepository(DataBaseContext bancoContext) 
        {
            _bancoContext = bancoContext;
        }

        public bool DeleteContact(int id)
        {
            Console.WriteLine("VERIFICA O ID:" + id);
            ContactModel contactToDelete = GetContact(id);
            if (contactToDelete == null)
            {
                throw new Exception("Houve um erro na exclusão do contato.");
            }
            Console.WriteLine("Removeu ID" + id);
            _bancoContext.Contatos.Remove(contactToDelete);
            _bancoContext.SaveChanges();
            return true;
        }

        public ContactModel EditContact(ContactModel contato)
        {
            ContactModel contactToEdit = GetContact(contato.Id);

            if (contactToEdit == null)
            {
                throw new Exception("Houve um erro na atualização do contato.");
            }

            contactToEdit.Name = contato.Name;
            contactToEdit.Email = contato.Email;
            contactToEdit.Celular = contato.Celular;

            _bancoContext.Contatos.Update(contactToEdit);
            _bancoContext.SaveChanges();
            return contactToEdit;
        }

        public ContactModel GetContact(int id)
        {
            return _bancoContext.Contatos.FirstOrDefault(contact => contact.Id == id);
        }

        public List<ContactModel> GetAllContacts() 
        {
            return _bancoContext.Contatos.ToList();//select all
        }

        public ContactModel AddContact(ContactModel contato)
        {         
            _bancoContext.Contatos.Add(contato);
            _bancoContext.SaveChanges();
            return contato;
        }
    }
}
