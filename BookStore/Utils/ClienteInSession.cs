using BookStore.Models;

namespace TccMvc.Services
{
    public static class ClienteInSession
    {
        public static int GetClienteIdFromSession(HttpContext httpContext)
        {
            var clienteIdStr = httpContext.Session.GetString("UserId");
            return int.Parse(clienteIdStr);
        }
        public static void SetClienteInSession(HttpContext httpContext, User user)
        {
            httpContext.Session.SetString("UserId", user.Id.ToString());
            httpContext.Session.SetString("UserName", user.Nome);
        }

    }
}
