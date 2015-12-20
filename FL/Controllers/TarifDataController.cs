using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using FL.Models;

namespace FL.Controllers
{
    public class TarifDataController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: /TarifData/
        public ActionResult Index()
        {
            return View(db.TarifsDatas.ToList());
        }

        // GET: /TarifData/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TarifData tarifdata = db.TarifsDatas.Find(id);
            if (tarifdata == null)
            {
                return HttpNotFound();
            }
            return View(tarifdata);
        }

        // GET: /TarifData/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /TarifData/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="TarifId,Name,Info,CreateDate,UpdateDate")] TarifData tarifdata)
        {
            if (ModelState.IsValid)
            {
                db.TarifsDatas.Add(tarifdata);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tarifdata);
        }

        // GET: /TarifData/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TarifData tarifdata = db.TarifsDatas.Find(id);
            if (tarifdata == null)
            {
                return HttpNotFound();
            }
            return View(tarifdata);
        }

        // POST: /TarifData/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="TarifId,Name,Info,CreateDate,UpdateDate")] TarifData tarifdata)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tarifdata).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tarifdata);
        }

        // GET: /TarifData/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TarifData tarifdata = db.TarifsDatas.Find(id);
            if (tarifdata == null)
            {
                return HttpNotFound();
            }
            return View(tarifdata);
        }

        // POST: /TarifData/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TarifData tarifdata = db.TarifsDatas.Find(id);
            db.TarifsDatas.Remove(tarifdata);
            db.SaveChanges();
            return RedirectToAction("Index");
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
