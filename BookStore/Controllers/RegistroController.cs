using BookStore.Models;
using BookStore.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;
using TccMvc.Cripitografia;
using TccMvc.Services;

namespace BookStore.Controllers
{
    public class RegistroController : Controller
    {
        private readonly IUnitOfWork _uow;

        public RegistroController(IUnitOfWork unitOfWork)
        {
            _uow = unitOfWork;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(User user)
        {
            if(ModelState.IsValid)
            {
                try
                {
                    var newUser = new User(user.Nome, user.Sobrenome, user.Email, Hash.MD5(user.Senha));
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
            }

            return View();
        }
    }
}
