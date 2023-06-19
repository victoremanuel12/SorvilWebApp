using BookStore.Models;
using BookStore.Repository.Interfaces;
using BookStore.Services;
using BookStore.Utils;
using BookStore.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace BookStore.Controllers
{
    public class HomeController : Controller
    {

        private readonly RequestApiBook _requestApiBook;
        private IUnitOfWork _uow;

        public HomeController(RequestApiBook requestApiBook, IUnitOfWork uow)
        {
            _requestApiBook = requestApiBook;
            _uow = uow;
        }

        public IActionResult Index()
        { 
            var user = _uow.UserRepository.GetUserBooks(ClienteInSession.UsuarioAutenticado.Id);
            HomeViewModel homeViewModel= new HomeViewModel();
            homeViewModel.LivrosNaoLidos = user.UserBooks.Where(x => x.Status == BookStatus.NaoLido).ToList();
            homeViewModel.LivrosLerei = user.UserBooks.Where(x => x.Status == BookStatus.Lerei).ToList();
            homeViewModel.LivrosLendo = user.UserBooks.Where(x => x.Status == BookStatus.Lendo).ToList();
            homeViewModel.LivrosConcluidos = user.UserBooks.Where(x => x.Status == BookStatus.Concluído).ToList();
            return View(homeViewModel);
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