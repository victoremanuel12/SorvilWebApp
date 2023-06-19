using BookStore.Models;
using BookStore.Repository.Interfaces;
using BookStore.Utils;
using BookStore.ViewModels;
using Microsoft.AspNetCore.Mvc;
using TccMvc.Cripitografia;

namespace BookStore.Controllers
{
    public class ConfiguracoesController : Controller
    {
        private readonly IUnitOfWork _uow;

        public ConfiguracoesController(IUnitOfWork unitOfWork)
        {
            _uow = unitOfWork;
        }
        public async  Task<IActionResult> Index()
        {
            User user = await _uow.UserRepository.GetById(ClienteInSession.UsuarioAutenticado.Id);

            var ViewModel = new UsuarioConfiguracaoViewModel
            {
                Id = user.Id,
                ImagemUsuario = user.ImagemUsuario,
                Email = user.Email,
                Nome = user.Nome,
                Senha = user.Senha,
                Sobrenome = user.Sobrenome,
            };
            return View(ViewModel);
        }
        [HttpPost]
        public async Task<IActionResult> Index(UsuarioConfiguracaoViewModel userAtualizado, IFormFile imagemFile)
        {
            if (ModelState.IsValid)
            {

                User user = await _uow.UserRepository.GetById(ClienteInSession.UsuarioAutenticado.Id);
                user.Nome = userAtualizado.Nome;
                user.Sobrenome = userAtualizado.Sobrenome;
                user.Email = userAtualizado.Email;
                if(user.Senha != userAtualizado.Senha)user.Senha = Hash.MD5(userAtualizado.Senha);
                if (imagemFile != null && imagemFile.Length > 0)
                {
                    using (var memoryStream = new MemoryStream())
                    {
                        await imagemFile.CopyToAsync(memoryStream);
                        byte[] imagemBytes = memoryStream.ToArray();

                        string imagemBase64 = Convert.ToBase64String(imagemBytes);
                        user.ImagemUsuario = imagemBase64;
                    }
                }
                _uow.UserRepository.Update(user);
                await _uow.Commit();
                ClienteInSession.RemoveClienteFromSession(HttpContext);
                ClienteInSession.SetClienteInSession(HttpContext, user);
                TempData["Success"] = "Dados atualizados com sucesso";

                return RedirectToAction("Index", "Home");
            }
            TempData["Error"] = "Não foi possível atualizar dados no momento!";
            return View();
        }
    }
}
