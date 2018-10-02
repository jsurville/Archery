using Archery.Data;
using Archery.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Archery.Areas.BackOffice.Controllers
{
    
    public class DashboardController : Controller
    {
        protected ArcheryDbContext db = new ArcheryDbContext();
        // GET: BackOffice/Dashboard
        public ActionResult Index()
        {
            return View();
        }

       
    }
}