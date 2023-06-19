using BookStore.Models;
using BookStore.Repository.Interfaces;
using BookStore.Services;
using BookStore.Utils;
using Microsoft.AspNetCore.Mvc;

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
                if (book.Result == null)
                {
                    TempData["Error"] = "Não foi possivel adicionar esse livro a sua prateleira";
                    return RedirectToAction("Index", "Home");

                }
                else
                {

                    User userInSession = ClienteInSession.GetClienteFromSession(HttpContext);
                    User user = await _uow.UserRepository.GetById(userInSession.Id);
                    var UserBook = new UserBook
                    {
                        BookId = book.Result.Id,
                        Author = string.Join("/", book.Result.VolumeInfo.Authors),
                        Description = book.Result.VolumeInfo.Description,
                        Image = book.Result.VolumeInfo.ImageLinks.Thumbnail,
                        IndustryIdentifier = book.Result.VolumeInfo.IndustryIdentifiers.ToString(),
                        Title = book.Result.VolumeInfo.Title,
                        PageCount = book.Result.VolumeInfo.PageCount,
                        PublishedDate = book.Result.VolumeInfo.PublishedDate,
                        UserId = user.Id,
                        User = user,
                        Status = (BookStatus)bookStatus,

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

