using ContactsControl.Models;
using ContactsControl.Repository;
using Microsoft.AspNetCore.Mvc;

namespace ContactsControl.Controllers
{
    public class ContactController : Controller
    {
        private readonly IContactRepository _contactRepository;
        public ContactController(IContactRepository contactRepository)
        {
            _contactRepository = contactRepository;
        }
        public IActionResult Index()
        {
            List<ContactModel> ContactList = _contactRepository.GetAllContacts();
            return View(ContactList);
        }
        public IActionResult CreateContact()
        {
            return View();
        }
        public IActionResult EditContact(int id)
        {
            ContactModel contato = _contactRepository.GetContact(id);
            return View(contato);
        }
        public IActionResult DeleteContact(int id)
        {
            Console.WriteLine("TELA DE EXCLUIR CADASTRO");
            ContactModel contato = _contactRepository.GetContact(id);
            return View(contato);
        }

        [HttpPost]
        public IActionResult CreateContact(ContactModel contato) 
        { 
            _contactRepository.AddContact(contato);
            return RedirectToAction("Index"); //retorna para uma ação, no caso index
        }

        [HttpPost]
        public IActionResult AlterContact(ContactModel contato)
        {
            _contactRepository.EditContact(contato);
            return RedirectToAction("Index");
        }

        public IActionResult ConfirmDeleteContact(int id)
        {
            Console.WriteLine("FUNÇÃO EXCLUIR CADASTRO");
            _contactRepository.DeleteContact(id);
            //_contactRepository.DeleteContact(contato);
            return RedirectToAction("Index");
        }
    }
}
