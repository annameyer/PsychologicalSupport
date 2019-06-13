using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using PsychologicalSupports.Authentication.Interface;
using PsychologicalSupports.Infrastructure;
using PsychologicalSupports.Models;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace PsychologicalSupports.Controllers
{
    [Authorize(Roles = "admin")]
    public class AdminController : Controller
    {
        private readonly ILoginRepository _LoginRepository;
        private readonly IRoleRepository _roleRepository;

        public AdminController(ILoginRepository loginRepository, IRoleRepository roleRepository)
        {
            _LoginRepository = loginRepository;
            _roleRepository = roleRepository;
        }

        private AppUserManager UserManager
        {
            get
            {
                return HttpContext.GetOwinContext().GetUserManager<AppUserManager>();
            }
        }

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
            return View(_LoginRepository.GetUsers());
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Delete()
        {
            return View();
        }

        [HttpPost, ActionName("Delete")]
        public async Task<ActionResult> DeleteConfirmed (string id)
        {
            var result =  await _LoginRepository.Delete(id);
            if (result == true)
            {
                return RedirectToAction("Index");
            }
            else
            {
                ModelState.AddModelError("", "Error");

            }
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Create(Administrator model)
        {
            if (ModelState.IsValid)
            {

                bool result = await _LoginRepository.Create(model);
                if (result == true)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("", "Error");

                }
            }
            return View(model);
        }

        public ActionResult ViewRole()
        {
            return View(_roleRepository.Get());
        }

        public ActionResult CreateRole()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> CreateRole(CreateRoleModel model)
        {
            if (ModelState.IsValid)
            {
                bool result = await _roleRepository.Create(model);
                if (result == true)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("", "Что-то пошло не так");
                }
            }
            return View(model);
        }


    }
}