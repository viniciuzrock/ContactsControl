using ContactsControl.Models;
using ContactsControl.Repository;
using Microsoft.AspNetCore.Mvc;

namespace ContactsControl.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserRepository _userRepository;
        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public IActionResult Index()
        {
            List<UserModel> UserList = _userRepository.GetAllUsers();
            return View(UserList);
        }

        public IActionResult CreateUser()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateUser(UserModel user)
        {
            try
            {
                if (ModelState.IsValid)//requisição banco só com dados do form validos
                {
                    _userRepository.AddUser(user);
                    TempData["MensagemSucesso"] = "Usuário cadastrado com sucesso.";
                    return RedirectToAction("Index");
                }
                return View(user); //se nao, retorna os dados que foram enviados
            }
            catch (Exception ex)
            {
                TempData["MensagemErro"] = "Não conseguimos cadastrar o usuário, tente novamente.\n" +
                    $"Detalhe do erro:{ex.Message}";
                return RedirectToAction("Index");
            }
        }
    }
}
