using BookStore.Models;
using BookStore.Services;
using BookStore.Utils;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace BookStore.Controllers
{
    public class HomeController : Controller
    {

        private readonly RequestApiBook _requestApiBook;

        public HomeController(RequestApiBook requestApiBook)
        {
            _requestApiBook = requestApiBook;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Logout()
        {
            if (BookStore.Utils.ClienteInSession.UsuarioAutenticado != null)
            {
                ClienteInSession.RemoveClienteFromSession(HttpContext);
            }

            return RedirectToAction("Index", "Apresentacao");
        }
    }
}