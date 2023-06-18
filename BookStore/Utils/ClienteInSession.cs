using BookStore.Models;
using Microsoft.CodeAnalysis.Elfie.Diagnostics;
using Newtonsoft.Json;

namespace BookStore.Utils
{
    public static class ClienteInSession
    {
        public static User UsuarioAutenticado { get; set; }

        public static User GetClienteFromSession(HttpContext httpContext)
        {
            string userJson = httpContext.Session.GetString("UserJson");
            UsuarioAutenticado = JsonConvert.DeserializeObject<User>(userJson);
            return UsuarioAutenticado;
        }
        public static void SetClienteInSession(HttpContext httpContext, User user)
        {
            UsuarioAutenticado = user;
            string UsuarioAutenticadoJson = JsonConvert.SerializeObject(user);
            httpContext.Session.SetString("UserJson", UsuarioAutenticadoJson);
        }

    }
}
