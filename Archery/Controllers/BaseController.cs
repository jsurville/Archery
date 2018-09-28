using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Archery.Data;
using Archery.Tools;

namespace Archery.Controllers
{
    public abstract class BaseController:Controller
    {
        protected ArcheryDbContext db = new ArcheryDbContext();
        /// <summary>
        /// Affiche un message dans le Layout success ou erreur avec ou sans type de message
        /// </summary>
        /// <param name="text"> le texte à afficher</param>
        /// <param name="type">le type de message</param>
        /// 
        protected void Display(string text , MesssageType type = MesssageType.SUCCESS)
        {
            var m = new Message(text, type);
            TempData["MESSAGE"] = m;
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            if (!disposing)
            {
                this.db.Dispose();
            }
        }

    }
}