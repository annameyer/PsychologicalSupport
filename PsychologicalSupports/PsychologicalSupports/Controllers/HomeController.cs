using System.Web.Mvc;

namespace PsychologicalSupports.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Emotional()
        {
            return View();
        }

        public ActionResult Intellectual()
        {
            return View();
        }

        public ActionResult Personal()
        {
            return View();
        }

        public ActionResult About()
        {
            return View();
        }
    }
}