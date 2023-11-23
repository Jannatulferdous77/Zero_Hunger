using System.Web.Mvc;

namespace ZeroHunger.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetStarted()
        {
            return View();
        }

        public ActionResult Logout()
        {
            Session.Abandon();
            Session.Clear();
            return RedirectToAction("Index", "Home");
        }
    }
}