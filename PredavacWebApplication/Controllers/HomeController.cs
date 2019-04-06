using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PredavacWebApplication.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Osnovne informacije o nama.";

            return View();
        }
        public ActionResult Contact()
        {
            ViewBag.Message = "Ukoliko imate problema s aplikacijom možete nas pronaći " +
                              "na navedenoj adresi ili nas kontaktirati putem navedenih" +
                              " e-mailova";

            return View();
        }
    }
}