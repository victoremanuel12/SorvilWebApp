using BookStore.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Controllers
{
    public class LoginController : Controller
    {
        private readonly IUnitOfWork _uow;

        public LoginController(IUnitOfWork unitOfWork)
        {
            _uow = unitOfWork;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
