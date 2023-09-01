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

        public IActionResult EditUser(int id)
        {
            UserModel user = _userRepository.GetUser(id);
            return View(user);  
        }

        public IActionResult DeleteUser(int id)
        {
            Console.WriteLine("TELA DE EXCLUIR CADASTRO");
            UserModel user = _userRepository.GetUser(id);
            return View(user);
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

        [HttpPost]
        public IActionResult AlterUser(EditUserModel userEdit)
        {
            try
            {
                UserModel user = null;

                if(ModelState.IsValid)
                {
                    user = new UserModel()
                    {
                        Id = userEdit.Id,
                        Nome = userEdit.Nome,
                        Login = userEdit.Login,
                        Email = userEdit.Email,
                        Perfil = userEdit.Perfil
                    };

                    user = _userRepository.EditUser(user);
                    TempData["MensagemSucesso"] = "Usuário atualizado com sucesso.";
                    return RedirectToAction("Index");
                }
                return View("EditUser", user);
            }
            catch(Exception ex)
            {
                TempData["MensagemErro"] = "Não conseguimos atualizar o seu contato, tente novamente.\n" +
                    $"Detalhe do erro:{ex.Message}";
                return View("Index"); //ele irá voltar para a view 'AlterContact' que não existe, então forçamos a view que ele deve buscar
            }
        }

        public IActionResult ConfirmDeleteUser(int id)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _userRepository.DeleteUser(id);
                    TempData["MensagemSucesso"] = "Contato excluído com sucesso.";
                    return RedirectToAction("Index");
                }
                UserModel user = _userRepository.GetUser(id);
                return View(user);
            }
            catch (Exception ex)
            {
                TempData["MensagemErro"] = "Não conseguimos excluir o usuário, tente novamente.\n" +
                    $"Detalhe do erro:{ex.Message}";
                return RedirectToAction("Index");
            }
        }

    }
}
