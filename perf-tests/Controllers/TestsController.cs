using System.Data.Entity;
using System.Net;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace MvcPerfTest.Controllers
{
    public class TestsController : Controller
    {
        private EfModel db = new EfModel();

        public async Task<ActionResult> Page1(int? id)
        {
            var model = id != null ? await db.Page1Models.FindAsync(id) : new Page1Model { };
            if (model == null) return HttpNotFound();
            return View(model);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<ActionResult> Page1(Page1Model model)
        {
            if (ModelState.IsValid)
            {
                if (model.Id != default(int))
                    db.Entry(model).State = EntityState.Modified;
                else
                    db.Page1Models.Add(model);

                await db.SaveChangesAsync();

                return RedirectToAction("Index");
            }

            return View(model);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
