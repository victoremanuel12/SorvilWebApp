using BookStore.DTOs;
using BookStore.Models;
using BookStore.Repository.Interfaces;
using BookStore.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Controllers
{
    public class UserBookController : Controller
    {
        private readonly IUnitOfWork _uow;

        public UserBookController(IUnitOfWork unitOfWork)
        {
            _uow = unitOfWork;
        }

        public async Task<IActionResult> Index(BookDetailsViewModel book, string bookStatus)
        {
            var UserBook = new UserBook
            {
                
            };
            _uow.UserBookRepository.Add(UserBook);
            return View();
        }
    }
}
