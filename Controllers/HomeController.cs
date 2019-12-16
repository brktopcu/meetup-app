using etkinlikSitesi.Models;
using EtkinlikSitesi.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace EtkinlikSitesi.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                SonEtkinlikler sonEtkinlik = new SonEtkinlikler();
                sonEtkinlik.etk = db.Etkinlik.OrderByDescending(x=>x.EtkinlikID).Take(4).ToList();
              

                return View(sonEtkinlik);
            }
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
        public class SonEtkinlikler
        {
            public List<Etkinlik> etk { get; set; }
        }
        public ActionResult ChangeCulture(string lang, string returnUrl)
        {
            Session["Culture"] = new CultureInfo(lang);
            return Redirect(returnUrl);
        }
    }
}