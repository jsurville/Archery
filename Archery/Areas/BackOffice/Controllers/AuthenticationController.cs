﻿using Archery.Areas.BackOffice.Models;
using Archery.Controllers;
using Archery.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Web.Mvc;

namespace Archery.Areas.BackOffice.Controllers
{
   [RouteArea("BackOffice")]
    public class AuthenticationController : BaseController
    {
        // GET: BackOffice/Authentication
        [Route("IdentificationAdmin")]
        public ActionResult Login()
        {
            return View();
        }

        // POST: BackOffice/Authentication
        [HttpPost]
        [Route("IdentificationAdmin")]
        [ValidateAntiForgeryToken]
        public ActionResult Login(AuthenticationLoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var hash = model.Password.ToMD5();
                var admin = db.Administrators.SingleOrDefault(
                    x => x.Email == model.Mail && x.Password == hash);
                if (admin == null)
                {
                    ModelState.AddModelError("Mail", "Login / Mot de Passe Incorrect");
                    return View();
                }
                else
                {
                    Session["ADMINISTRATOR"] = admin; // ouverture d'une session serveur pour l'utilisateur admin qui vient de se conncter
                    TempData["Name"] = admin.FirstName.ToString() + " " + admin.LastName.ToString();
                    return RedirectToAction("index", "dashboard", new { area = "BackOffice" });
                }
            }
            return View();
        }

        // POST: BackOffice/Authentication
        
        
        public ActionResult Logout()
        {
            Session.Remove("ADMINISTRATOR");
           // Session["ADMINISTRATOR"] = null; // fermeture de la session serveur pour l'utilisateur admin qui était connecté
                    return RedirectToAction("index", "home", new { area = "" });
         
        }
    }
}