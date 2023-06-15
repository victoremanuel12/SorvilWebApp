using BookStore.Models;
using BookStore.Services;
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


        public async Task<IActionResult> Index()
        {
            try
            {
                var books = await _requestApiBook.SearchBooks("Seja foda!");
            }
            catch (Exception)
            {
                TempData["Error"] = "Não foi possivel carregar  os livros no momento!";
                
            }
            return View();
        }

       
    }
}