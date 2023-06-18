using BookStore.Models;
using BookStore.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;
using TccMvc.Cripitografia;
using TccMvc.Services;

namespace BookStore.Controllers
{
    public class UserAccount : Controller
    {
        private readonly IUnitOfWork _uow;

        public UserAccount(IUnitOfWork unitOfWork)
        {
            _uow = unitOfWork;
        }

        public IActionResult Login()
        {
            return View();
        }

        public IActionResult Logout()
        {
            if (HttpContext.Session.GetString("UserId") != null)
            {
                ClienteInSession.GetClienteIdFromSession(HttpContext);
                HttpContext.Session.Clear();
                TempData["Success"] = "Logout efetuado com sucesso";
            }
            return RedirectToAction("Index", "Home");
        }
    }
}
