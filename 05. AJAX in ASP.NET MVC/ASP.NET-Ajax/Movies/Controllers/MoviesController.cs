using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Movies.Models;
using Movies.Data;
using Movies.ViewModels;
using PagedList;
using System.Security;

namespace Movies.Controllers
{
    public class MoviesController : Controller
    {
        private readonly MovieContext db = new MovieContext();

        // GET: /Movies/
        //[SecuritySafeCritical]
        public ActionResult Index()
        {
            var model = db.Movies.ToList();
                            //.OrderBy(m => m.Title)
                            //.ToPagedList(page, 5);
            return View(model);
        }

        // GET: /Movies/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Movie movie = db.Movies.Find(id);
            if (movie == null)
            {
                return HttpNotFound();
            }

            if (Request.IsAjaxRequest())
            {
                return PartialView("_Details", movie);
            }

            return View(movie);
        }

        // GET: /Movies/Create
        public ActionResult Create()
        {
            if (Request.IsAjaxRequest())
            {
                return PartialView("_Create");
            }

            return View();
        }

        // POST: /Movies/Create
        // To protect from over posting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        // 
        // Example: public ActionResult Update([Bind(Include="ExampleProperty1,ExampleProperty2")] Model model)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Exclude = "Id")] MovieViewModel movie)
        {
            if (ModelState.IsValid)
            {
                Movie newMovie = new Movie()
                {
                    Title = movie.Title,
                    Director = movie.Director,
                    LeadingFemaleRole = movie.LeadingFemaleRole,
                    LeadingMaleRole = movie.LeadingMaleRole,
                    Studio = movie.Studio,
                    StudioAddress = movie.StudioAddress,
                    Year = movie.Year
                };

                db.Movies.Add(newMovie);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(movie);
        }

        // GET: /Movies/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Movie movie = db.Movies.Find(id);
            if (movie == null)
            {
                return HttpNotFound();
            }

            MovieViewModel editedMovie = new MovieViewModel()
            {
                Title = movie.Title,
                Director = movie.Director,
                LeadingFemaleRole = movie.LeadingFemaleRole,
                LeadingMaleRole = movie.LeadingMaleRole,
                Studio = movie.Studio,
                StudioAddress = movie.StudioAddress,
                Year = movie.Year
            };

            if (Request.IsAjaxRequest())
            {
                return PartialView("_Edit", editedMovie);
            }

            return View(movie);
        }

        // POST: /Movies/Edit/5
        // To protect from over posting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        // 
        // Example: public ActionResult Update([Bind(Include="ExampleProperty1,ExampleProperty2")] Model model)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(MovieViewModel movie, int id)
        {
            if (ModelState.IsValid)
            {
                Movie movieForEdit = db.Movies.Find(id);
                movieForEdit.Title = movie.Title;
                movieForEdit.Director = movie.Director;
                movieForEdit.Studio = movie.Studio;
                movieForEdit.StudioAddress = movie.StudioAddress;
                movieForEdit.Year = movie.Year;
                movieForEdit.LeadingFemaleRole = movie.LeadingFemaleRole;
                movieForEdit.LeadingMaleRole = movie.LeadingMaleRole;
                db.Entry(movieForEdit).State = EntityState.Modified;
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            return View(movie);
        }

        // GET: /Movies/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Movie movie = db.Movies.FirstOrDefault(m => m.Id == id);

            if (movie == null)
            {
                return HttpNotFound();
            }

            if (Request.IsAjaxRequest())
            {
                return PartialView("_Delete", movie);
            }

            return View(movie);
        }

        // POST: /Movies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Movie movie = db.Movies.FirstOrDefault(m => m.Id == id);
            db.Movies.Remove(movie);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}
