using System;
using System.Data.Entity;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace MvcPerfTest.Controllers
{
    public partial class TestsController : Controller
    {
        private EfModel db = new EfModel();

        public virtual async Task<ActionResult> Index()
        {
            return View(await db.Tests.ToArrayAsync());
        }

        [HttpPost, ValidateAntiForgeryToken]
        public virtual async Task<ActionResult> BeginTest()
        {
            if (ModelState.IsValid)
            {
                var test = db.Tests.Add(new Test { Start = DateTimeOffset.Now });
                var rowsAffected = await db.SaveChangesAsync();
                if (rowsAffected != 1) throw new ApplicationException("The test could not be created successfully");
                return RedirectToAction(MVC.Tests.Page1(test.Id));
            }

            return View();
        }

        public virtual async Task<ActionResult> Page1(int? id)
        {
            var model = id != null ? await db.Page1Models.FindAsync(id) : new Page1Model { };
            if (model == null) return HttpNotFound();
            return View(model);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public virtual async Task<ActionResult> Page1(Page1Model model)
        {
            if (ModelState.IsValid)
            {
                if (model.Id == default(int)) db.Page1Models.Add(model);
                else db.Entry(model).State = EntityState.Modified;

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
