using Archery.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Archery.Controllers
{
    public class HomeController : BaseController
    {
        // GET: Home
        public ActionResult Index()
        {

            //Session["test"] = "rtest";
            
            ViewData["Title"] = "Accueil";  // pour ajouter un titre à la View
            return View(db.Tournaments.Include("Pictures").OrderBy(x => x.StartDate).ToList());
        }

        // GET: /Tournaments/Details/5
        public ActionResult Details(int? id)
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
            return View(tournament);
        }

        [Route("a-propos")] // pour mapper directement vers "a-propos" mais ne pas oublier de signaler la route routes.MapMvcAttributeRoutes() dans le controller
        public ActionResult About()
        {
            var modelInfo = new Info
            {
                DevName = "Julien SURVILLE",
                ContactMail = "julien.surville@gmail.com",
                CreatedDate = DateTime.Now
            };

            return View(modelInfo);
        }
    }
}