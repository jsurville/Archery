using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Archery.Data;
using Archery.Models;

namespace Archery.Areas.BackOffice.Controllers
{
    public class TournamentsController : Controller
    {
        private ArcheryDbContext db = new ArcheryDbContext();

        // GET: BackOffice/Tournaments
        public ActionResult Index()
        {
            return View(db.Tournaments.ToList());
        }

        // GET: BackOffice/Tournaments/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tournament tournament = db.Tournaments.Include("BowList").SingleOrDefault(x => x.ID == id);
            if (tournament == null)
            {
                return HttpNotFound();
            }
            return View(tournament);
        }

        // GET: BackOffice/Tournaments/Create
        public ActionResult Create()
        {
            MultiSelectList bowTypeValues = new MultiSelectList(db.BowTypes, "ID", "Name");
            ViewData["Bowtypes"] = bowTypeValues;
            return View();
        }

        // POST: BackOffice/Tournaments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Name,Location,Capacity,StartDate,EndDate,FeePerson,Description")] Tournament tournament, int[] BowsID)
        {
            if (ModelState.IsValid)
            {

                tournament.BowList = new List<BowType>();
                
                foreach (var item in BowsID)
                {
                    tournament.BowList.Add(db.BowTypes.Find(item));
                }
                db.Tournaments.Add(tournament);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            MultiSelectList bowTypeValues = new MultiSelectList(db.BowTypes, "ID", "Name");
            ViewData["Bowtypes"] = bowTypeValues;
            return View(tournament);
        }

        // GET: BackOffice/Tournaments/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tournament tournament = db.Tournaments.Include("Pictures").Include("BowList").SingleOrDefault(x => x.ID == id);
            if (tournament == null)
            {
                return HttpNotFound();
            }
            MultiSelectList bowTypeValues = new MultiSelectList(db.BowTypes, "ID", "Name", tournament.BowList.Select(x => x.ID));
            ViewData["Bowtypes"] = bowTypeValues;
            return View(tournament);
        }

        // POST: BackOffice/Tournaments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,Location,Capacity,StartDate,EndDate,FeePerson,Description,Pictures")] Tournament tournament, int[] BowsID)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tournament).State = EntityState.Modified; // Modifcation d'objet avec relation many to many

                tournament = db.Tournaments.Include("BowList").Include("Pictures").SingleOrDefault(x => x.ID == tournament.ID); // la liste des bows que l'objet tournament en cache contient
                if (BowsID != null)
                    tournament.BowList = db.BowTypes.Where(x => BowsID.Contains(x.ID)).ToList(); // les ID des bows que l'objet tournament du formulaire contient
                else
                    tournament.BowList.Clear();
                
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            MultiSelectList bowTypeValues = new MultiSelectList(db.BowTypes, "ID", "Name");
            ViewData["Bowtypes"] = bowTypeValues;
            return View(tournament);
        }

        [HttpPost]
        public ActionResult AddPicture(HttpPostedFileBase picture, int id)
        {
            if(picture?.ContentLength >0)
            {
                var tp = new TournamentPicture();
                tp.ContentType = picture.ContentType;
                tp.Name = picture.FileName;
                tp.TournamentID = id;

                using(var reader = new BinaryReader(picture.InputStream))
                {
                    tp.Content = reader.ReadBytes(picture.ContentLength);
                }
                db.TournamentPictures.Add(tp);
                db.SaveChanges();
                return RedirectToAction("edit", "tournaments", new { id = id });
            }
            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        }

        // GET
        public ActionResult DeletePicture(int id, int idtournoi)
        {
                TournamentPicture image = db.TournamentPictures.Find(id);
                db.TournamentPictures.Remove(image);
                db.Entry(image).State = EntityState.Deleted;
                db.SaveChanges();
            // return Json(image);
                return RedirectToAction("edit", "tournaments", new { id = idtournoi });
        }


        // GET: BackOffice/Tournaments/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tournament tournament = db.Tournaments.Find(id);
            if (tournament == null)
            {
                return HttpNotFound();
            }
            return View(tournament);
        }

        // POST: BackOffice/Tournaments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Tournament tournament = db.Tournaments.Include("BowList").SingleOrDefault(x => x.ID == id);
            tournament.BowList.Clear();

            var shooters = db.Shooters.Where(x => x.TournamentID == id);
            foreach (var item in shooters)
            {
                db.Entry(item).State = EntityState.Deleted;  // équivalent à db.Shooters.Remove(item);
            }

            db.Tournaments.Remove(tournament);
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
