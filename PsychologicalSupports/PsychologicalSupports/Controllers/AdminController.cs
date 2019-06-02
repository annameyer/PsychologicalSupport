using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using PsychologicalSupports.Infrastructure;
using PsychologicalSupports.Models;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace PsychologicalSupports.Controllers
{
    public class AdminController : Controller
    {
        private AppUserManager UserManager => HttpContext.GetOwinContext().GetUserManager<AppUserManager>();
        private void AddErrorsFromResult(IdentityResult result)
        {
            foreach (string error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }
        }
        // GET: Admin
        public ActionResult Index()
        {
            return View(UserManager.Users);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Create(Administrator model)
        {
            if (ModelState.IsValid)
            {
                AppUser user = new AppUser { UserName = model.Login };
                IdentityResult result = await UserManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    AddErrorsFromResult(result);
                }
            }
            return View(model);
        }




    }
}