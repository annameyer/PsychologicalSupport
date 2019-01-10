using Microsoft.Owin.Security;
using PsychologicalSupports.Models;
using System.Threading.Tasks;
using System.Web.Mvc;
using PsychologicalSupports.Authentication.Interface;

namespace PsychologicalSupports.Controllers
{
    public class AccountController : Controller
    {
        private readonly ILoginRepository _LoginRepository;
        private readonly IAuthenticationManager _authManager;

        public AccountController(ILoginRepository loginRepository, IAuthenticationManager authManager)
        {
            _LoginRepository = loginRepository;
            _authManager = authManager;
        }

        public ActionResult Login(string returnUrl)
        {
            ViewBag.returnUrl = returnUrl;
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Login(Administrator details)
        {
            var user = await _LoginRepository.Login(details);

                if (user == false)
                {
                    ModelState.AddModelError("", "Некорректное имя или пароль");
                }
                else
                {
                return RedirectToAction("Index", "Students");
            }
                return View(details);
        }

        [HttpPost]
        public ActionResult LogOff()
        {
            _LoginRepository.SignOut(_authManager);
            return RedirectToAction("Index", "Students");
        }
        
    }
}