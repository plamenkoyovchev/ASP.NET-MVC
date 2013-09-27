using _03.InformationalSystem.Models;
using _03.InformationalSystem.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _03.InformationalSystem.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext context = new ApplicationDbContext();
        //
        // GET: /Category/
        public ActionResult Index()
        {
            var categories = context.Categories.ToList();

            return View(categories);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreateCategoryViewModel model)
        {
            if (ModelState.IsValid)
            {
                Category newCat = new Category() 
                {
                    CategoryName = model.CategoryName
                };

                context.Categories.Add(newCat);
                context.SaveChanges();
                return Redirect("Index");
            }

            return View(model);
        }
	}
}