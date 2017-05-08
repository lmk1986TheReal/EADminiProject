using System;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using EADMiniProject.DAL;
using EADMiniProject.Models;
using System.Data.Entity.Infrastructure;



namespace EADMiniProject.Controllers
{
    public class MusicianController : Controller
    {
        private ArtistContext db = new ArtistContext();

        // GET: Musician
        public ViewResult Index(string sortOrder, string searchString)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.MusicianFirstNameSortParam = sortOrder == "MusicianFirstName" ? "MusicianFirstName-desc" : "MusicianFirstName";
            ViewBag.MusicianLastNameSortParam = sortOrder == "MusicianLastName" ? "MusicianLastName-desc" : "MusicianLastName";
            ViewBag.NatSortParm = sortOrder == "Nationality" ? "Nationality_desc" : "Nationality";
            ViewBag.YearsActiveSortParam = sortOrder == "YearsActive" ? "YearsActive-desc" : "YearsActive";
            ViewBag.PrimaryInstrumentSortParam = sortOrder == "PrimaryInstrument" ? "PrimaryInstrument-desc" : "PrimaryInstrument";
            ViewBag.GenreSortParam = sortOrder == "Genre" ? "Genre-desc" : "Genre";
            var Musicians = from s in db.Musicians
                           select s;

            if (!String.IsNullOrEmpty(searchString))
            {
                Musicians = Musicians.Where(m => m.MusicianFirstName.Contains(searchString)
                                       || m.MusicianLastName.Contains(searchString)
                                       || m.Genre.Contains(searchString)
                                       || m.PrimaryInstrument.Contains(searchString));
            }

            switch (sortOrder)
            {
                // Start First Name 
                case "MusicianFirstName":
                    Musicians = Musicians.OrderBy(m => m.MusicianFirstName);
                    break;
                case "MusicianFirstName-desc":
                    Musicians = Musicians.OrderByDescending(m => m.MusicianFirstName);
                    break;
                // end Frist Name 

                // Start Last Name
                case "MusicianLastName":
                    Musicians = Musicians.OrderBy(m => m.MusicianLastName);
                    break;
                case "MusicianLastName-desc":
                    Musicians = Musicians.OrderByDescending(m => m.MusicianLastName);
                    break;
                // End Last Name

                // Start Nationality 
                case "Nationality":
                    Musicians = Musicians.OrderBy(m => m.Nationality);
                    break;
                case "Nationality_desc":
                    Musicians = Musicians.OrderByDescending(m => m.Nationality);
                    break;
                // End Nationality  

                // Start Years Active 
                case "YearsActive":
                    Musicians = Musicians.OrderBy(m => m.YearsActive);
                    break;
                case "YearsActive_desc":
                    Musicians = Musicians.OrderByDescending(m => m.YearsActive);
                    break;
                // End Years Active

                // Start Primary Instrument
                case "PrimaryInstrument":
                    Musicians = Musicians.OrderBy(m => m.PrimaryInstrument);
                    break;
                case "PrimaryInstrument_desc":
                    Musicians = Musicians.OrderByDescending(m => m.PrimaryInstrument);
                    break;
                // End Primary Instrument

                // Start Genre
                case "Genre":
                    Musicians = Musicians.OrderBy(m => m.Genre);
                    break;
                case "Genre_desc":
                    Musicians = Musicians.OrderByDescending(m => m.Genre);
                    break;
                    // End Genre
            }
            return View(Musicians.ToList());
        }

        // GET: Musician/Details/5
        public ActionResult Details(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Musician musician = db.Musicians.Find(id);
            if (musician == null)
            {
                return HttpNotFound();
            }
            return View(musician);
        }

        // GET: Musician/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Musician/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MusicianID,MusicianFirstName,MusicianLastName,Nationality,YearsActive,PrimaryInstrument,Genre")] Musician musician)
        {
            try
            {
                if (ModelState.IsValid)
            {
                db.Musicians.Add(musician);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            }
            catch (RetryLimitExceededException  /* dex */)
            {
                //Log the error (uncomment dex variable name and add a line here to write a log.
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }
            return View(musician);
        }

        // GET: Musician/Edit/5
        public ActionResult Edit(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Musician musician = db.Musicians.Find(id);
            if (musician == null)
            {
                return HttpNotFound();
            }
            return View(musician);
        }

        // POST: Musician/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public ActionResult EditPost([Bind(Include = "ID,MusicianFirstName,MusicianLastName,Genre,Nationality,YearsActive,PrimaryInstrument")] Musician mus)
        {
            if (ModelState.IsValid)
            {
                db.Entry(mus).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(mus);
        }

        // GET: Musician/Delete/5
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
            Musician musician = db.Musicians.Find(id);
            if (musician == null)
            {
                return HttpNotFound();
            }
            return View(musician);
        }

        // POST: Musician/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Musician musician = db.Musicians.Find(id);
            db.Musicians.Remove(musician);
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
