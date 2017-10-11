using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcDemo_25July2017.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
           ViewBag.Countries = new List<string> { "Sri Lanka", "India", "Pakistan" };
            ViewData["Cities"] = new List<string> { "Veyangoda", "Nittambuwa", "Gampaha" };
            return View();
        }

    }
        
        
}