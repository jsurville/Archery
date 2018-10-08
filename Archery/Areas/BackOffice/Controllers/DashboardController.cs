using Archery.Data;
using Archery.Filters;
using Archery.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Archery.Areas.BackOffice.Controllers
{
    [Authentication]
    public class DashboardController : Controller
    {
        protected ArcheryDbContext db = new ArcheryDbContext();


        // GET: BackOffice/Dashboard
        //[Route("Administration")]
        public ActionResult Index()
        {
            //@TempData["AdminName"];
            return View();
        }

       
    }
}