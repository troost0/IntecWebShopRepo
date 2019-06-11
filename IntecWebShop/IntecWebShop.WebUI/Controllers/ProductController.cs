using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IntecWebShop.Core.Models;
using IntecWebShop.Core.ViewModels;
using IntecWebShop.DataAcces.InMemory.Repositories;

namespace IntecWebShop.WebUI.Controllers
{
    public class ProductController : Controller
    {
        public ProductRepository _productContext = new ProductRepository();
        public ProductCategoryRepository _productCategoryContext = new ProductCategoryRepository();

        // GET: Product
        public ActionResult Index()
        {
            var products = _productContext.Collection().ToList(); 

            return View(products);
        }


        [HttpGet]
        public ActionResult Create()
        {
            ProductManagerViewModel viewmodel = new ProductManagerViewModel();
            viewmodel.Product = new Product();
            viewmodel.ProductCategories = _productCategoryContext.Collection();

            return View(viewmodel);
        }

        [HttpPost]
        public ActionResult Create(Product product)
        {
            if (!ModelState.IsValid)
                return View();

            _productContext.Insert(product);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Delete(string id)
        {
            var productToDelete = _productContext.FindProduct(id);
            return View(productToDelete);
        }


        [HttpPost]
        [ActionName("Delete")]
        public ActionResult ConfirmDelete(string id)
        {
            if (!_productContext.Delete(id))
                return HttpNotFound();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(string id)
        {
            ProductManagerViewModel viewmodel = new ProductManagerViewModel();
            viewmodel.Product = _productContext.FindProduct(id);
            viewmodel.ProductCategories = _productCategoryContext.Collection();

            return View(viewmodel);
        }

        [HttpPost]
        public ActionResult Edit(Product product)
        {
            _productContext.Update(product);

            return RedirectToAction("Index");
        }

    }
}