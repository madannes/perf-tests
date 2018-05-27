using System.Web.Mvc;

namespace MvcPerfTest.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}