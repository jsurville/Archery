using Archery.Models;
using Archery.Data;
using Archery.Tools;
using System.Web.Mvc;
using System.Collections.Generic;
using System.Security.Cryptography;

namespace Archery.Controllers
{
    public class ArchersController : BaseController
    {
       
        // GET: Players
        public ActionResult Subscribe()
        {
            return View();
        }

        public ActionResult List( )
        {
            var dbArchers = db.Archers;
            List<Archer> ArcherList = new List<Archer>();
            foreach (Archer element in dbArchers)
            {
                Archer archer = element;
                ArcherList.Add(archer);
            }
            return View(ArcherList);
        }

        // POST: Players
        [HttpPost]  // restreint la méthode Subscribe à la méhtode Htttp de type POST
        [ValidateAntiForgeryToken] // PREMIER ELEMENT DE SECURITE A METTRE EN PLACE indique au serveur qu'il doit valider un jeton anti-intrusion
        public ActionResult Subscribe([Bind(Exclude ="ID")]Archer archer ) // {Bind( ... )] pour ne récupérer que les paramètres de la requête dont j'ai besoin: ici, on exclut l'ID
        {

            //if(DateTime.Now.AddYears(-9) <= archer.BirthDate)
            //{
            //    // ViewBag.Erreur = "L'age n'est pas bon";
            //    // return View();
            //    ModelState.AddModelError("Birthdate", "Date de Naissance invalide: l'âge doit être au minimu de 9 ans"); // et l'erreur apparaitra dans la view car on valide sur la BirthDate
            //}
            
            if (ModelState.IsValid)
            {
                archer.Password.ToMD5(); // Méthode d'extention
                
                    db.Configuration.ValidateOnSaveEnabled = false;
                    db.Archers.Add(archer);
                    db.SaveChanges();
                    db.Configuration.ValidateOnSaveEnabled = true;
                    Display("Le Nouveau Tireur a bien été enregistré");
                    return RedirectToAction("index", "home");
            }
            
            return View();
        }









    }
}