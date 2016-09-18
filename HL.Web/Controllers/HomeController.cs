using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HL.Core.Infrastructure;
using HL.Core.Ioc;
using HL.Data;
using HL.Domain;

namespace HL.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return Content("index");
        }

        public ActionResult About()
        {
            


            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}