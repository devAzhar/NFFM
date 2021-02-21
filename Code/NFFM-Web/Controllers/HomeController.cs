using NFFM.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NFFM.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var data = Database.GetDataTable("select * from tblTruckers;");
            return View();
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