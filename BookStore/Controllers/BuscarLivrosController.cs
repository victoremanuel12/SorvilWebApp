using BookStore.DTOs;
using BookStore.Services;
using BookStore.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using PagedList;

namespace BookStore.Controllers
{
    public class BuscarLivrosController : Controller
    {
        private readonly RequestApiBook _requestApiBook;

        public BuscarLivrosController(RequestApiBook requestApiBook)
        {
            _requestApiBook = requestApiBook;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> List(string titleBook)
        {
            try
            {
                var viewModel = new BookViewModel();
                if (!string.IsNullOrEmpty(titleBook))
                {
                    var books = await _requestApiBook.SearchBooks(titleBook);
                    viewModel.Items = books.Items;
                    return View(viewModel);
                }
                else
                {
                    return View(viewModel);
                }

            }
            catch
            {
                TempData["Error"] = "Não foi possivel carregar  os livros no momento!";

            }
            return View();
        }

        public async Task<IActionResult> Details(string bookId)
        {
            try
            {
                if (!string.IsNullOrEmpty(bookId))
                {
                    var book = await _requestApiBook.GetBookById(bookId);
                    var viewModel = new BookDetailsViewModel
                    {
                        Id = book.Id,
                        Authors = book.VolumeInfo.Authors,
                        Description = book.VolumeInfo.Description,
                        ImageLinks = book.VolumeInfo.ImageLinks,
                        IndustryIdentifiers = book.VolumeInfo.IndustryIdentifiers,
                        PageCount = book.VolumeInfo.PageCount,
                        PublishedDate = book.VolumeInfo.PublishedDate,
                        Title = book.VolumeInfo.Title
                    };
                    return View(viewModel);
                }
            }
            catch
            {

                TempData["Error"] = "Não foi possível localizar o livro";
            }


            return View();
        }

    }
}
