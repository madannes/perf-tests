using System.Web.Mvc;

namespace MvcPerfTest.Controllers
{
    public partial class HomeController : Controller
    {
        public virtual ActionResult Index()
        {
            return View();
        }
    }
}