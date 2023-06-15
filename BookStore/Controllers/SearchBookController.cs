using BookStore.Services;
using BookStore.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Controllers
{
    public class SearchBookController : Controller
    {
        private readonly RequestApiBook _requestApiBook;

        public SearchBookController(RequestApiBook requestApiBook)
        {
            _requestApiBook = requestApiBook;
        }
        public async Task<IActionResult> Index(string titleBook)
        {
            try
            {
                var books = await _requestApiBook.SearchBooks(titleBook);
                var ViewModel = new BookViewModel
                {
                };
            }
            catch (Exception)
            {
                TempData["Error"] = "Não foi possivel carregar  os livros no momento!";

            }
            return View();
        }
    }
}
