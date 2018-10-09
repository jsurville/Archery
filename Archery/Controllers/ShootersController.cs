﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.WebPages;
using Archery.Data;
using Archery.Filters;
using Archery.Models;

namespace Archery.Controllers
{
    [AuthenticationArcher]
    public class ShootersController : BaseController
    {
       // private ArcheryDbContext db = new ArcheryDbContext();

        // GET: Shooters
        public ActionResult Index()
        {
            var shooters = db.Shooters.Include(s => s.Archer).Include(s => s.BowType).Include(s => s.Tournament);
            return View(shooters.ToList());
        }

        // GET: Shooters/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Shooter shooter = db.Shooters.Find(id);
            if (shooter == null)
            {
                return HttpNotFound();
            }
            return View(shooter);
        }

        // GET: Shooters/Create
        public ActionResult Create()
        {
            ViewBag.ArcherID = new SelectList(db.Archers, "ID", "LicenseNumber");
            ViewBag.BowTypeID = new SelectList(db.BowTypes, "ID", "Name");
            ViewBag.TournamentID = new SelectList(db.Tournaments, "ID", "Name");
            return View();
        }

        // POST: Shooters/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,TournamentID,BowTypeID,ArcherID,StatTime")] Shooter shooter)
        {
            if (ModelState.IsValid)
            {
                var shooterTournament = db.Tournaments.SingleOrDefault(x => x.ID == shooter.TournamentID);
                
                shooter.StatTime = shooterTournament.StartDate;
                db.Shooters.Add(shooter);
                db.SaveChanges();
                
                string message = "Votre inscription au " + shooterTournament.Name + " a bien été prise en compte. Vous recevrez un email de confirmation avec votre heure de départ. Merci ...";
                Display(message);
                
                return RedirectToAction("details", "home", new { id = shooter.TournamentID });
                
            }

            ViewBag.ArcherID = new SelectList(db.Archers, "ID", "LicenseNumber", shooter.ArcherID);
            ViewBag.BowTypeID = new SelectList(db.BowTypes, "ID", "Name", shooter.BowTypeID);
            ViewBag.TournamentID = new SelectList(db.Tournaments, "ID", "Name", shooter.TournamentID);
            return View(shooter);
        }

        // GET: Shooters/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Shooter shooter = db.Shooters.Find(id);
            if (shooter == null)
            {
                return HttpNotFound();
            }
            ViewBag.ArcherID = new SelectList(db.Archers, "ID", "LicenseNumber", shooter.ArcherID);
            ViewBag.BowTypeID = new SelectList(db.BowTypes, "ID", "Name", shooter.BowTypeID);
            ViewBag.TournamentID = new SelectList(db.Tournaments, "ID", "Name", shooter.TournamentID);
            return View(shooter);
        }

        // POST: Shooters/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,TournamentID,BowTypeID,ArcherID,StatTime")] Shooter shooter)
        {
            if (ModelState.IsValid)
            {
                db.Entry(shooter).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ArcherID = new SelectList(db.Archers, "ID", "LicenseNumber", shooter.ArcherID);
            ViewBag.BowTypeID = new SelectList(db.BowTypes, "ID", "Name", shooter.BowTypeID);
            ViewBag.TournamentID = new SelectList(db.Tournaments, "ID", "Name", shooter.TournamentID);
            return View(shooter);
        }

        // GET: Shooters/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Shooter shooter = db.Shooters.Find(id);
            if (shooter == null)
            {
                return HttpNotFound();
            }
            return View(shooter);
        }

        // POST: Shooters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Shooter shooter = db.Shooters.Find(id);
            db.Shooters.Remove(shooter);
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
