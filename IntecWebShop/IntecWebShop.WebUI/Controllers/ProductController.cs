using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IntecWebShop.Core.Models;
using IntecWebShop.DataAcces.InMemory.Repositories;

namespace IntecWebShop.WebUI.Controllers
{
    public class ProductController : Controller
    {
        public ProductRepository Context { get; set; } = new ProductRepository();

        // GET: Product
        public ActionResult Index()
        {
            var products = Context.Collection().ToList(); 

            return View(products);
        }


        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Product product)
        {
            if (!ModelState.IsValid)
                return View();

            Context.Insert(product);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Delete(string id)
        {
            var productToDelete = Context.FindProduct(id);
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
            return View(Context.FindProduct(id));
        }

        [HttpPost]
        public ActionResult Edit(Product product)
        {
            Context.Update(product);

            return RedirectToAction("Index");
        }

    }
}