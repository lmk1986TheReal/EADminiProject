using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EADMiniProject.DAL;
using EADMiniProject.ViewModels;

namespace EADMiniProject.Controllers
{
    public class HomeController : Controller
    {
        private ArtistContext db = new ArtistContext();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            IQueryable<NationalityCounts> data = from musician in db.Musicians
                                                   group musician by musician.Nationality into discipline
                                                  select new NationalityCounts()
                                                   {
                                                       Nationality = discipline.Key,
                                                      NationalityCount = discipline.Count()
                                                   };
            return View(data.ToList());
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}