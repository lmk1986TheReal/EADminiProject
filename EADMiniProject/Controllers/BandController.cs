using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EADMiniProject.DAL;
using EADMiniProject.Models;
using System.Data.Entity.Infrastructure;



namespace EADMiniProject.Controllers
{
    public class BandController : Controller
    {
        private ArtistContext db = new ArtistContext();

        // GET: Band
        public ViewResult Index(string sortOrder, string searchString)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.BandNameSortParm = sortOrder == "BandName" ? "BandName-desc" : "BandName";
            ViewBag.MembersSortParm = sortOrder == "Members" ? "Members-desc" : "Members";
            ViewBag.NatSortParm = sortOrder == "Nationality" ? "Nationality_desc" : "Nationality";
            ViewBag.YearsActiveSortParam = sortOrder == "YearsActive" ? "YearsActive-desc" : "YearsActive";
            ViewBag.GenreSortParam = sortOrder == "Genre" ? "Genre-desc" : "Genre";
            var Bands = from b in db.Bands
                        select b;

            if (!String.IsNullOrEmpty(searchString))
            {
                Bands = Bands.Where(b => b.BandName.Contains(searchString)
                                       || b.Genre.Contains(searchString));
            }
            switch (sortOrder)
            {
                // Start name 
                case "BandName":
                    Bands = Bands.OrderBy(b => b.NumberofBandMembers);
                    break;
                case "BandName-desc":
                    Bands = Bands.OrderByDescending(b => b.NumberofBandMembers);
                    break;
                // end name 

                // Start Number of Members
                case "Members":
                    Bands = Bands.OrderBy(b => b.NumberofBandMembers);
                    break;
                case "Members-desc":
                    Bands = Bands.OrderByDescending(b => b.NumberofBandMembers);
                    break;
                // End number of members

                // Start Nationality 
                case "Nationality":
                    Bands = Bands.OrderBy(b => b.Nationality);
                    break;
                case "Nationality_desc":
                    Bands = Bands.OrderByDescending(b => b.Nationality);
                    break;
                // End Nationality  

                // Start Years Active 
                case "YearsActive":
                    Bands = Bands.OrderBy(b => b.YearsActive);
                    break;
                case "YearsActive_desc":
                    Bands = Bands.OrderByDescending(b => b.YearsActive);
                    break;
                // End Years Active

                // Start Genre
                case "Genre":
                    Bands = Bands.OrderBy(b => b.Genre);
                    break;
                case "Genre_desc":
                    Bands = Bands.OrderByDescending(b => b.Genre);
                    break;
                // End Genre

            }
            return View(Bands.ToList());
        }

        // GET: Band/Details/5
        public ActionResult Details(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Band band = db.Bands.Find(id);
            if (band == null)
            {
                return HttpNotFound();
            }
            return View(band);
        }

        // GET: Band/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Band/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "BandID,BandName,NumberofBandMembers,Nationality,YearsActive,Genre")] Band band)
        {
            try
            {
                if (ModelState.IsValid)
            {
                db.Bands.Add(band);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            }
            catch (RetryLimitExceededException  /* dex */)
            {
                //Log the error (uncomment dex variable name and add a line here to write a log.
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }
            return View(band);
        }

        // GET: Band/Edit/5
        public ActionResult Edit(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Band band = db.Bands.Find(id);
            if (band == null)
            {
                return HttpNotFound();
            }
            return View(band);
        }

        // POST: Band/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public ActionResult EditPost([Bind(Include = "ID,BandName,NumberofBandMembers,Genre,Nationality,YearsActive")] Band band)
        {
            if (ModelState.IsValid)
            {
                db.Entry(band).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(band);
        }

        // GET: Band/Delete/5
        public ActionResult Delete(int? id, bool? saveChangesError = false)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            if (saveChangesError.GetValueOrDefault())
            {
                ViewBag.ErrorMessage = "Delete failed. Try again, and if the problem persists see your system administrator.";
            }
            Band band = db.Bands.Find(id);
            if (band == null)
            {
                return HttpNotFound();
            }
            return View(band);
        }

        // POST: Band/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Band band = db.Bands.Find(id);
            db.Bands.Remove(band);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
