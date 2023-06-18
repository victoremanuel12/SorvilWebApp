using BookStore.Models;
using BookStore.Repository.Interfaces;
using BookStore.ViewModels;
using Microsoft.AspNetCore.Mvc;
using TccMvc.Cripitografia;
using TccMvc.Services;

namespace BookStore.Controllers
{
    public class LoginController : Controller
    {
        private readonly IUnitOfWork _uow;

        public LoginController(IUnitOfWork unitOfWork)
        {
            _uow = unitOfWork;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(LoginViewModel user)
        {
            if(ModelState.IsValid)
            {
                if (user != null)
                {
                    var usuarioCadastrado = await _uow.UserRepository.Get(u => u.Email == user.Email && u.Senha == Hash.MD5(user.Senha));
                    if (usuarioCadastrado != null)
                    {
                        TempData["Success"] = "Login efetuado com sucesso!";
                        ClienteInSession.SetClienteInSession(HttpContext, usuarioCadastrado);
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        TempData["Error"] = " Usuario ou senha não encontrados";
                    }
                }
            }
            return View();
        }
    }
}
