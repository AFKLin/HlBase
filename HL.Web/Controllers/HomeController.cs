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
            var a=Bootstrapper.Current.Container.Reslove<IUnitOfWork>();
            a.Repostory<MyNews>().Insert(new MyNews()
            {
                Name = "123",
                Aget = 1
            });
            a.Commit();
            return Content("xxxx");
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}