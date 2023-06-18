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

        public IActionResult Index()
        {
            return View();
        }
       
    }
}