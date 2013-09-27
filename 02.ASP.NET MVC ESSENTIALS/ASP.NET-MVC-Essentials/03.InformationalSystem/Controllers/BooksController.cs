using _03.InformationalSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using _03.InformationalSystem.ViewModel;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity;
using System.Data.Entity;

namespace _03.InformationalSystem.Controllers
{
    public class BooksController : Controller
    {
        private readonly ApplicationDbContext context = new ApplicationDbContext();
        //
        // GET: /Book/
        public ActionResult Index()
        {
            var books = context.Books;

            return View(books);
        }

        public ActionResult Create(CreateBookVewModel model)
        {
            if (ModelState.IsValid)
            {
                Book newBook = new Book()
                {
                    Title = model.Title,
                    Content = model.Content,
                    CategoryId = int.Parse(model.SelectedValue),
                    UserId = ControllerContext.HttpContext.User.Identity.GetUserId()
                };

                context.Books.Add(newBook);
                context.SaveChanges();
                return Redirect("Index");
            }

            GetCategoriesInDropDownList(model);

            return View(model);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var model = context.Books.Find(id);
            CreateBookVewModel newModel = new CreateBookVewModel()
            {
                Title = model.Title,
                Content = model.Content,
                SelectedValue = model.CategoryId.ToString()
            };

            GetCategoriesInDropDownList(newModel);
            return View(newModel);
        }

        [HttpPost]
        public ActionResult Edit(CreateBookVewModel model, int id)
        {
            if (ModelState.IsValid)
            {
                var modelForEdit = context.Books.Find(id);
                modelForEdit.Title = model.Title;
                modelForEdit.Content = model.Content;
                modelForEdit.CategoryId = int.Parse(model.SelectedValue);
                modelForEdit.UserId = ControllerContext.HttpContext.User.Identity.GetUserId();
                context.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(model);
        }

        public ActionResult Delete(int id)
        {
            try
            {
                var modelForDelete = context.Books.Find(id);
                context.Books.Remove(modelForDelete);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            { 
                throw new Exception(ex.Message);
            }
            //return HttpNotFound("Book not found. You cannot delete it.");
        }

        public ActionResult Details(int id)
        {
            var model = context.Books.Find(id);

            return View(model);
        }

        private void GetCategoriesInDropDownList(CreateBookVewModel model)
        {
            model.BookCategories = context.Categories.ToList().Select(c => new SelectListItem
            {
                Text = c.CategoryName,
                Value = c.Id.ToString()
            }).ToList();
        }

        protected override void Dispose(bool disposing)
        {
            context.Dispose();
            base.Dispose(disposing);
        }
    }
}