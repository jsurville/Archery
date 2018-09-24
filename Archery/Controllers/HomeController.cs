﻿using Archery.Models;
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
            return View();
        }
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