using IntecWebShop.Core.Models;
using IntecWebShop.DataAcces.InMemory.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IntecWebShop.WebUI.Controllers
{
    public class ProductCategoryController : Controller
    {
        public ProductCategoryRepository Context { get; set; } = new ProductCategoryRepository();

        // GET: Product
        public ActionResult Index()
        {
            var categories = Context.Collection().ToList();

            return View(categories);
        }


        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(ProductCategory model)
        {
            if (!ModelState.IsValid)
                return View();

            Context.Insert(model);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Delete(string id)
        {
            var productToDelete = Context.FindProductCategory(id);
            return View(productToDelete);
        }


        [HttpPost]
        [ActionName("Delete")]
        public ActionResult ConfirmDelete(string id)
        {
            if (!Context.Delete(id))
                return HttpNotFound();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(string id)
        {
            return View(Context.FindProductCategory(id));
        }

        [HttpPost]
        public ActionResult Edit(ProductCategory category)
        {
            Context.Update(category);

            return RedirectToAction("Index");
        }
    }
}