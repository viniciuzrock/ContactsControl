using Microsoft.AspNetCore.Mvc;

namespace ContactsControl.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
