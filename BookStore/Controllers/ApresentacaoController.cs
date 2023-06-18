using Microsoft.AspNetCore.Mvc;

namespace BookStore.Controllers
{
    public class ApresentacaoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
