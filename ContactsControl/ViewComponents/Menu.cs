using ContactsControl.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ContactsControl.ViewComponents
{
    public class Menu : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            string sessaoUsuario = HttpContext.Session.GetString("sessaoUsuarioLogado");
            
            if (string.IsNullOrEmpty(sessaoUsuario)) return null;

            UserModel user = JsonConvert.DeserializeObject<UserModel>(sessaoUsuario);
            return View(user);
        }
    }
}
