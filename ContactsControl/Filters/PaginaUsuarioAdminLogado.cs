using ContactsControl.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;
using System.Net.Mime;

namespace ContactsControl.Filters
{
    public class PaginaUsuarioAdminLogado : ActionFilterAttribute//usado somente para validar a sessao da rota
    {
        //Executa antes da ação do controler e depois do model ser vinculado
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            string sessaoUsuario = context.HttpContext.Session.GetString("sessaoUsuarioLogado");

            if(string.IsNullOrEmpty(sessaoUsuario))//se nao houver sessao
            {                   //rota que será direcionada
                context.Result = new RedirectToRouteResult(new RouteValueDictionary
                {   //Pasta , Arquivo
                    {"controller","Login" },
                    {"action", "Index" }
                });//ação 'index' da controler de login
            }
            else
            {
                UserModel usuario = JsonConvert.DeserializeObject<UserModel>(sessaoUsuario);

                if(usuario == null)
                {
                    context.Result = new RedirectToRouteResult(new RouteValueDictionary
                    {   //Pasta , Arquivo
                        {"controller","Login" },
                        {"action", "Index" }
                    });//ação 'index' da controler de login
                }

                if(usuario.Perfil != Enums.ProfileEnum.Admin)
                {
                    context.Result = new RedirectToRouteResult(new RouteValueDictionary
                    {   //Pasta , Arquivo
                        {"controller","Restrito" },
                        {"action", "Index" }
                    });//ação 'index' da controler de login
                }
            }
            base.OnActionExecuting(context);
        }
    }
}
