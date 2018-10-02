using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Archery.Models;

namespace Archery.Areas.BackOffice.Controllers
{
    public class BowTypesController : Controller
    {
        private ArcheryContext db = new ArcheryContext();

        // GET: BackOffice/BowTypes
        public ActionResult Index()
        {
            return View(db.BowTypes.ToList());
        }

        // GET: BackOffice/BowTypes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BowType bowType = db.BowTypes.Find(id);
            if (bowType == null)
            {
                return HttpNotFound();
            }
            return View(bowType);
        }

        // GET: BackOffice/BowTypes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BackOffice/BowTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Name")] BowType bowType)
        {
            if (ModelState.IsValid)
            {
                db.BowTypes.Add(bowType);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(bowType);
        }

        // GET: BackOffice/BowTypes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BowType bowType = db.BowTypes.Find(id);
            if (bowType == null)
            {
                return HttpNotFound();
            }
            return View(bowType);
        }

        // POST: BackOffice/BowTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name")] BowType bowType)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bowType).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(bowType);
        }

        // GET: BackOffice/BowTypes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BowType bowType = db.BowTypes.Find(id);
            if (bowType == null)
            {
                return HttpNotFound();
            }
            return View(bowType);
        }

        // POST: BackOffice/BowTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BowType bowType = db.BowTypes.Find(id);
            db.BowTypes.Remove(bowType);
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
