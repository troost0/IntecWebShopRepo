using IntecWebShop.Core.Interfaces;
using IntecWebShop.Core.Models;
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
        public ActionResult Index()
        {
            List<Product> products = _productContext.Collection().ToList();
            return View(products);
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