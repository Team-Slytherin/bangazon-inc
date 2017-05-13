using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using bangazon_inc.DAL;
using bangazon_inc.Interfaces;

namespace bangazon_inc.Controllers
{
    public class HomeController : Controller
    {
        private AppContext db = new AppContext();


        public ActionResult Index()
        {
            ViewBag.Categories = db.Categories.ToList();
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

        public ActionResult Category()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}