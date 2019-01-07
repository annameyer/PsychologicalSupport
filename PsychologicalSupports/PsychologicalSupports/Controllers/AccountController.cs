using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using PsychologicalSupports.Infrastructure;
using PsychologicalSupports.Models;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using PsychologicalSupports.Models.Dependencies;

namespace PsychologicalSupports.Controllers
{
    public class AccountController : Controller
    {
        private readonly ILoginRepository _LoginRepository;
        private readonly IAuthenticationManager _authManager;
        // GET: Account
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
                    ModelState.AddModelError("", "Name or password was wrong.");
                }
                else
                {
                    return RedirectToAction("Index", "Team");
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