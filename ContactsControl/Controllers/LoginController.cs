using ContactsControl.Helpers;
using ContactsControl.Models;
using ContactsControl.Repository;
using Microsoft.AspNetCore.Mvc;

namespace ContactsControl.Controllers
{
    public class LoginController : Controller
    {
        private readonly IUserRepository _userRepository;
        private readonly ISessao _sessao;

        public LoginController(IUserRepository userRepository, ISessao sessao) 
        {
            _userRepository = userRepository;
            _sessao = sessao;
        }

        public IActionResult Index()
        {
            if (_sessao.GetISessaoUser() != null)
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        public IActionResult Exit()
        {
            _sessao.RemoveISessaoUser();
            return RedirectToAction("Index", "Login");
        }

        [HttpPost]
        public IActionResult Enter(LoginModel loginModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    UserModel user =  _userRepository.GetUserByLogin(loginModel.Login);
                    if (user != null)
                    {
                        if (user.PasswordIsValid(loginModel.Password))
                        {
                            _sessao.CreateISessaoUser(user);
                            return RedirectToAction("Index", "Home");
                        }
                        TempData["MensagemErro"] = "Senha inválida, tente novamente.";
                    }
                    TempData["MensagemErro"] = "Usuário ou senha inválidos, tente novamente.";
                }
                return View("Index");
            }catch (Exception ex)
            {
                TempData["MensagemErro"] = "Não conseguimos verificar seu login, tente novamente.\n" +
                   $"Detalhe do erro:{ex.Message}";
                return RedirectToAction("Index");
            }
        }
    }
}
