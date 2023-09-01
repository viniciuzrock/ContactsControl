using Microsoft.AspNetCore.Mvc;

namespace ContactsControl.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
