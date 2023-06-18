using Microsoft.AspNetCore.Mvc;

namespace BookStore.Controllers
{
    public class RegistroController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
