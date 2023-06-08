using Microsoft.AspNetCore.Mvc;

namespace BookStore.Controllers
{
    public class UserAccount : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
