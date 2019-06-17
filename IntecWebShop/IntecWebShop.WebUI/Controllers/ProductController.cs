using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IntecWebShop.Core.Interfaces;
using IntecWebShop.Core.Models;
using IntecWebShop.Core.ViewModels;
using IntecWebShop.DataAcces.InMemory.Repositories;

namespace IntecWebShop.WebUI.Controllers
{
    public class ProductController : Controller
    {
        public IRepository<Product> _productContext;
        public IRepository<ProductCategory> _productCategoryContext;

        public ProductController(IRepository<Product> productContext, IRepository<ProductCategory> productCategroyContext)
        {
            _productContext = productContext;
            _productCategoryContext = productCategroyContext;
        }

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
        public ActionResult Create(Product product, HttpPostedFileBase file)
        {
            if (!ModelState.IsValid)
                return View();


            if (file != null)
            {
                product.Image = product.Id + Path.GetExtension(file.FileName);
                file.SaveAs(Server.MapPath(@"/Content/ProductImages/") + product.Image);
            }
            
            _productContext.Insert(product);
            _productContext.Commit();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Delete(string id)
        {
            var productToDelete = _productContext.FindInList(id);
            return View(productToDelete);
        }


        [HttpPost]
        [ActionName("Delete")]
        public ActionResult ConfirmDelete(string id)
        {
            if (!_productContext.Delete(id))
                return HttpNotFound();

            _productContext.Commit();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(string id)
        {
            ProductManagerViewModel viewmodel = new ProductManagerViewModel();
            viewmodel.Product = _productContext.FindInList(id);
            viewmodel.ProductCategories = _productCategoryContext.Collection();

            return View(viewmodel);
        }

        [HttpPost]
        public ActionResult Edit(Product product, HttpPostedFileBase file)
        {
            if (ModelState.IsValid)
            {
                if (file != null)
                {
                    product.Image = product.Id + Path.GetExtension(file.FileName);
                    file.SaveAs(Server.MapPath(@"/Content/ProductImages/") + product.Image);
                }

                _productContext.Update(product);

                _productContext.Commit();
            }
            return RedirectToAction("Index");
        }

    }
}