using IntecWebShop.Core.Interfaces;
using IntecWebShop.Core.Models;
using IntecWebShop.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IntecWebShop.WebUI.Controllers
{
    public class HomeController : Controller
    {

        public IRepository<Product> _productContext;
        public IRepository<ProductCategory> _productCategoryContext;

        public HomeController(IRepository<Product> productContext, IRepository<ProductCategory> productCategroyContext)
        {
            _productContext = productContext;
            _productCategoryContext = productCategroyContext;
        }
        public ActionResult Index(string category = null)
        {
            var productCategories = _productCategoryContext.Collection().ToList();
            var products = _productContext.Collection().ToList();

            if (category == null)
                products = _productContext.Collection().ToList();
            else
                products = _productContext.Collection().Where(x => x.Category == category).ToList();

            var viewModel = new ProductListViewModel();

            viewModel.Categories = productCategories;
            viewModel.Products = products;

            return View(viewModel);
        }



        public ActionResult Details(string id)
        {
            var product = _productContext.FindInList(id);
            if (product == null)
                return HttpNotFound();

            return View(product);
        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}