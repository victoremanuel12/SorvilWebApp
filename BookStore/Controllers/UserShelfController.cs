using BookStore.Models;
using BookStore.Repository.Interfaces;
using BookStore.Services;
using BookStore.Utils;
using BookStore.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Controllers
{
    public class UserShelfController : Controller
    {
        private readonly IUnitOfWork _uow;
        private readonly RequestApiBook _requestApiBook;

        public UserShelfController(IUnitOfWork unitOfWork, RequestApiBook requestApiBook)
        {
            _uow = unitOfWork;
            _requestApiBook = requestApiBook;

        }
        public IActionResult List()
        {
            var books = new List<UserBook>();
            User userInSession = ClienteInSession.GetClienteFromSession(HttpContext);
            User userBooks =  _uow.UserRepository.GetUserBooks(userInSession.Id);
            foreach (var book in userBooks.UserBook)
            {
                books.Add(book);
            }
            var viewModel = new BookOnShelfViewModel
            {
                Books = books,
            };
            return View(viewModel);
        }
    }
}
