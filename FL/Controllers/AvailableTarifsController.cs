﻿using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using FL.Models;

namespace FL.Controllers
{
    public class AvailableTarifsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: /AvailableTarifs/
        public ActionResult Index()
        {
            return View(db.AvailableTarifs.ToList());
        }

        // GET: /AvailableTarifs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AvailableTarif availabletarif = db.AvailableTarifs.Find(id);
            if (availabletarif == null)
            {
                return HttpNotFound();
            }
            return View(availabletarif);
        }

        // GET: /AvailableTarifs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /AvailableTarifs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="AvailableTarifId,Price,StartDate,EndDate,DurationDays")] AvailableTarif availabletarif)
        {
            if (ModelState.IsValid)
            {
                db.AvailableTarifs.Add(availabletarif);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(availabletarif);
        }

        // GET: /AvailableTarifs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AvailableTarif availabletarif = db.AvailableTarifs.Find(id);
            if (availabletarif == null)
            {
                return HttpNotFound();
            }
            return View(availabletarif);
        }

        // POST: /AvailableTarifs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="AvailableTarifId,Price,StartDate,EndDate,DurationDays")] AvailableTarif availabletarif)
        {
            if (ModelState.IsValid)
            {
                db.Entry(availabletarif).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(availabletarif);
        }

        // GET: /AvailableTarifs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AvailableTarif availabletarif = db.AvailableTarifs.Find(id);
            if (availabletarif == null)
            {
                return HttpNotFound();
            }
            return View(availabletarif);
        }

        // POST: /AvailableTarifs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AvailableTarif availabletarif = db.AvailableTarifs.Find(id);
            db.AvailableTarifs.Remove(availabletarif);
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