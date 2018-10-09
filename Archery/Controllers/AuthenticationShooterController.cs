using Archery.Areas.BackOffice.Models;
using Archery.Controllers;
using Archery.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Web.Mvc;

namespace Archery.Controllers
{
   
    public class AuthenticationShooterController : BaseController
    {
        // GET: /Authentication
       [Route("Identification")]
        public ActionResult Login()
        {
            return View();
        }

        // POST: /Authentication
        [HttpPost]
        [Route("Identification")]
        [ValidateAntiForgeryToken]
        public ActionResult Login(AuthenticationLoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var hash = model.Password.ToMD5();
                var archer = db.Archers.SingleOrDefault(
                    x => x.Email == model.Mail && x.Password == hash);
                if (archer == null)
                {
                    ModelState.AddModelError("Mail", "Login / Mot de Passe Incorrect");
                    return View();
                }
                else
                {
                    Session["ARCHER"] = archer; // ouverture d'une session serveur pour l'utilisateur admin qui vient de se conncter
                   // ViewBag.Archer = archer;
                    TempData["Name"] = archer.FirstName.ToString() + " " + archer.LastName.ToString();
                    TempData["LicenseArcher"] = archer.LicenseNumber;
                    TempData["IDArcher"] = archer.ID;
                    return RedirectToAction("index", "shooters");
                }
            }

            return View();
        }

        // POST: /Authentication
        
        
        public ActionResult Logout()
        {
            Session.Remove("ARCHER");
            Display("Vous avez été déconnecté. A bientôt");
            // Session["ARCHER"] = null; // fermeture de la session serveur pour l'utilisateur admin qui était connecté
            return RedirectToAction("index", "home", new { area = "" });
         
        }
    }
}