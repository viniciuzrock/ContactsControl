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
            try
            {
                if (ModelState.IsValid)//requisição banco só com dados do form validos
                {
                    _contactRepository.AddContact(contato);
                    TempData["MensagemSucesso"] = "Contato cadastrado com sucesso.";
                    return RedirectToAction("Index");
                }
                return View(contato); //se nao, retorna os dados que foram enviados
            }
            catch (Exception ex)
            {
                TempData["MensagemErro"] = "Não conseguimos cadastrar o seu contato, tente novamente.\n" +
                    $"Detalhe do erro:{ex.Message}";
                return RedirectToAction("Index");
            }            
        }

        [HttpPost]
        public IActionResult AlterContact(ContactModel contato)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _contactRepository.EditContact(contato);
                    TempData["MensagemSucesso"] = "Contato atualizado com sucesso.";
                    return RedirectToAction("Index");
                }
                return View("EditContact", contato);
            }
            catch (Exception ex)
            {
                TempData["MensagemErro"] = "Não conseguimos atualizar o seu contato, tente novamente.\n" +
                    $"Detalhe do erro:{ex.Message}";
                return View("EditContact", contato); //ele irá voltar para a view 'AlterContact' que não existe, então forçamos a view que ele deve buscar
            }
        }

        public IActionResult ConfirmDeleteContact(int id)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _contactRepository.DeleteContact(id);
                    TempData["MensagemSucesso"] = "Contato excluído com sucesso.";
                    return RedirectToAction("Index");
                }
                ContactModel contato = _contactRepository.GetContact(id);
                return View(contato);
            }
            catch (Exception ex)
            {
                TempData["MensagemErro"] = "Não conseguimos excluir o seu contato, tente novamente.\n" +
                    $"Detalhe do erro:{ex.Message}";
                return RedirectToAction("Index");
            }
        }
    }
}
