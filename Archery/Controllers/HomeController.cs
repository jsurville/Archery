using Archery.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Archery.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            ViewData["Title"] = "Accueil";  // pour ajouter un titre à la View
            return View();
        }

        [Route("a-propos")] // pour mapper directement vers "a-propos" mais ne pas oublier de signaler la route routes.MapMvcAttributeRoutes() dans le controller
        public ActionResult About()
        {
            var modelInfo = new Info
            {
                DevName = "Julien SURVILLE",
                ContactMail = "julien.surville.gmail",
                CreatedDate = DateTime.Now
            };

            return View(modelInfo);
        }
    }
}