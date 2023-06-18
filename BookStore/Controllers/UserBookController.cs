using BookStore.Models;
using BookStore.Repository.Interfaces;
using BookStore.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TccMvc.Services;

namespace BookStore.Controllers
{
    public class UserBookController : Controller
    {
        private readonly IUnitOfWork _uow;
        private readonly RequestApiBook _requestApiBook;

        public UserBookController(IUnitOfWork unitOfWork, RequestApiBook requestApiBook)
        {
            _uow = unitOfWork;
            _requestApiBook = requestApiBook;

        }

        public async Task<IActionResult> Index(string bookId, int bookStatus)
        {
            try
            {
                var book = _requestApiBook.GetBookById(bookId);
                string Authors = "";
                if (book.Result == null)
                {
                    TempData["Error"] = "Não foi possivel adicionar esse livro a sua prateleira";
                    return RedirectToAction("Index", "Home");

                }
                else
                {
                    foreach (var authors in book.Result.VolumeInfo.Authors)
                    {
                        Authors += "/" + authors;
                    }
                    //User user = await _uow.UserRepository.GetById(ClienteInSession.GetClienteFromSession(HttpContext));
                    User user = await _uow.UserRepository.GetById(7);
                    var UserBook = new UserBook
                    {
                        BookId = book.Result.Id,
                        Author = Authors,
                        Description = book.Result.VolumeInfo.Description,
                        Image = book.Result.VolumeInfo.ImageLinks.Thumbnail,
                        IndustryIdentifier = book.Result.VolumeInfo.IndustryIdentifiers.ToString(),
                        Title = book.Result.VolumeInfo.Title,
                        PageCount = book.Result.VolumeInfo.PageCount,
                        PublishedDate = book.Result.VolumeInfo.PublishedDate,
                        UserId = 7, //user.Id
                        User = user, //user
                        Status = (BookStatus)bookStatus
                    };
                    _uow.UserBookRepository.Add(UserBook);
                    await _uow.Commit();
                    TempData["Success"] = "Não foi possivel adicionar esse livro a sua prateleira";
                    return RedirectToAction("Index", "Home");

                };
            }
            catch
            {
                TempData["Error"] = "Não foi possivel adicionar esse livro a sua prateleira";
                return RedirectToAction("Index", "Home");
            }


        }

    }
}

