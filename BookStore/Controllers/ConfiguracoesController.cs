using Microsoft.AspNetCore.Mvc;

namespace BookStore.Controllers
{
    public class ConfiguracoesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
