using Archery.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Archery.Controllers
{
    public class ArchersController : Controller
    {
        // GET: Players
        public ActionResult Subscribe()
        {
            return View();
        }

        // POST: Players
        [HttpPost]  // restreint la méthode Subscribe à la méhtode Htttp de type POST
        public ActionResult Subscribe(Archer archer )
        {
            
            //if(DateTime.Now.AddYears(-9) <= archer.BirthDate)
            //{
            //    // ViewBag.Erreur = "L'age n'est pas bon";
            //    // return View();
            //    ModelState.AddModelError("Birthdate", "Date de Naissance invalide: l'âge doit être au minimu de 9 ans"); // et l'erreur apparaitra dans la view car on valide sur la BirthDate
            //}

            if (ModelState.IsValid)
            {
                
            }
            return View();
        }



    }
}