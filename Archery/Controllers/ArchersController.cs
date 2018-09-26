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
            
            if (ModelState.IsValid)
            {
                
            }
           




            int a = 7;
            int b = 23;
            string.Format("Demain la température sera comprise entre {0} et {1} °C", a, b);

            return View();
        }



    }
}