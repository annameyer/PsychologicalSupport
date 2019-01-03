using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using PsychologicalSupports.Infrastructure;
using PsychologicalSupports.Models;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace PsychologicalSupports.Controllers
{
    public class AccountController : Controller
    {
        private PsychologicalSupportsEntities db = new PsychologicalSupportsEntities();
        // GET: Account
        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            ViewBag.returnUrl = returnUrl;
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(Administrator details, string returnUrl)
        {
            if (details.Login == null || details.Password == null)
            {
                ModelState.AddModelError("", "Некорректное имя или пароль.");
            }
            else
            {
                AppUser user = await UserManager.FindAsync(details.Login, details.Password);
                if (user == null)
                {
                    ModelState.AddModelError("", "Некорректное имя или пароль.");
                }
                else
                {
                    ClaimsIdentity ident = await UserManager.CreateIdentityAsync(user,
                        DefaultAuthenticationTypes.ApplicationCookie);

                    AuthManager.SignOut();
                    AuthManager.SignIn(new AuthenticationProperties
                    {
                        IsPersistent = false
                    }, ident);
                    return Redirect(returnUrl);
                }
            }
            return View(details);
        }

        private IAuthenticationManager AuthManager
        {
            get
            {
                return HttpContext.GetOwinContext().Authentication;
            }
        }

        private AppUserManager UserManager
        {
            get
            {
                return HttpContext.GetOwinContext().GetUserManager<AppUserManager>();
            }
        }
    }
}