using ContactsControl.Filters;
using Microsoft.AspNetCore.Mvc;

namespace ContactsControl.Controllers
{
    [PaginaUsuarioLogado]
    public class RestritoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
