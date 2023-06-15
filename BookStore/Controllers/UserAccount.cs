using BookStore.Models;
using BookStore.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;
using TccMvc.Cripitografia;
using TccMvc.Services;

namespace BookStore.Controllers
{
    public class UserAccount : Controller
    {
        private readonly IUnitOfWork _uow;

        public UserAccount(IUnitOfWork unitOfWork)
        {
            _uow = unitOfWork;
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(User user)
        {
            if (user !=null)
            {
                var usuarioCadastrado = await _uow.UserRepository.Get(u => u.Email == user.Email && u.Password == Hash.MD5(user.Password));
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
           
            return View();
        }
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(User user)
        {
            try
            {
                var newUser = new User(user.Name, user.Email, Hash.MD5(user.Password));
                _uow.UserRepository.Add(newUser);
                await _uow.Commit();
                ClienteInSession.SetClienteInSession(HttpContext, newUser);
                TempData["Success"] = "Cadastro efetuado com sucesso.";
                return RedirectToAction("Index", "Home");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                TempData["Error"] = "Não foi possível efetuar o cadastro";
            }
            return View();
        }

        public IActionResult Logout()
        {
            if (HttpContext.Session.GetString("UserId") != null)
            {
                ClienteInSession.GetClienteIdFromSession(HttpContext);
                HttpContext.Session.Clear();
                TempData["Success"] = "Logout efetuado com sucesso";
            }
            return RedirectToAction("Index", "Home");
        }
    }
}
