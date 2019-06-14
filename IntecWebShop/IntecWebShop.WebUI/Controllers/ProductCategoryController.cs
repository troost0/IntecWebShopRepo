using IntecWebShop.Core.Interfaces;
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
        public IRepository<ProductCategory> _context;

        public ProductCategoryController(IRepository<ProductCategory> productCategoryContext)
        {
            _context = productCategoryContext;
        }

        // GET: Product
        public ActionResult Index()
        {
            var categories = _context.Collection().ToList();

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

            _context.Insert(model);

            _context.Commit();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Delete(string id)
        {
            var productToDelete = _context.FindInList(id);
            return View(productToDelete);
        }


        [HttpPost]
        [ActionName("Delete")]
        public ActionResult ConfirmDelete(string id)
        {
            if (!_context.Delete(id))
                return HttpNotFound();

            _context.Commit();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(string id)
        {
            return View(_context.FindInList(id));
        }

        [HttpPost]
        public ActionResult Edit(ProductCategory model)
        {
            _context.Update(model);

            _context.Commit();

            return RedirectToAction("Index");
        }
    }
}