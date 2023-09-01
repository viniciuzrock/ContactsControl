using ContactsControl.Models;
using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace ContactsControl.Helpers
{
    public class Sessao: ISessao
    {
        private readonly IHttpContextAccessor _httpContext;

        public Sessao(IHttpContextAccessor httpContext) 
        {
            _httpContext = httpContext;
        }

        public void CreateISessaoUser(UserModel user)
        {
            string valor = JsonConvert.SerializeObject(user);
            _httpContext.HttpContext.Session.SetString("sessaoUsuarioLogado",valor);
        }

        public UserModel GetISessaoUser()
        {
            string sessionUser = _httpContext.HttpContext.Session.GetString("sessaoUsuarioLogado");
            if (string.IsNullOrEmpty(sessionUser))
            {
                return null;
            }
            return JsonConvert.DeserializeObject<UserModel>(sessionUser);
        }

        public void RemoveISessaoUser()
        {
            _httpContext.HttpContext.Session.Remove("sessaoUsuarioLogado");
        }
    }
}
