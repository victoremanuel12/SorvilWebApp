using BookStore.DTOs;
using BookStore.Services;
using BookStore.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace BookStore.Controllers
{
    public class SearchBookController : Controller
    {
        private readonly RequestApiBook _requestApiBook;

        public SearchBookController(RequestApiBook requestApiBook)
        {
            _requestApiBook = requestApiBook;
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
                    var book = _requestApiBook.GetBookById(bookId);
                    var viewModel = new BookDetailsViewModel
                    {
                        Id = book.Result.Id,
                        Authors = book.Result.VolumeInfo.Authors,
                        Description = book.Result.VolumeInfo.Description,
                        ImageLinks = book.Result.VolumeInfo.ImageLinks,
                        IndustryIdentifiers = book.Result.VolumeInfo.IndustryIdentifiers,
                        PageCount = book.Result.VolumeInfo.PageCount,
                        PublishedDate = book.Result.VolumeInfo.PublishedDate,
                        Title = book.Result.VolumeInfo.Title
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
