using BookStore.Models;
using Newtonsoft.Json;

namespace TccMvc.Services
{
    public static class ClienteInSession
    {
        public static User GetClienteFromSession(HttpContext httpContext)
        {
            string userJson = httpContext.Session.GetString("UserJson");
            User user = JsonConvert.DeserializeObject<User>(userJson);
            return user;
        }
        public static void SetClienteInSession(HttpContext httpContext, User user)
        {
            string userJson = JsonConvert.SerializeObject(user);
            httpContext.Session.SetString("UserJson", userJson);
        }

    }
}
