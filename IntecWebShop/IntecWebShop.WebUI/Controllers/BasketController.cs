﻿using IntecWebShop.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IntecWebShop.WebUI.Controllers
{
    public class BasketController : Controller
    {
        IBasketService _basketService;

        public BasketController(IBasketService basketService)
        {
            _basketService = basketService;
        }

        // GET: Basket
        public ActionResult Index()
        {
            var model = _basketService.GetBasketItems(HttpContext);
            return View(model);
        }

        public ActionResult AddToBasket(string id)
        {
            _basketService.AddToBasket(HttpContext, id);

            return RedirectToAction("Index","Home");
        }

        public ActionResult RemoveFromBasket(string id)
        {
            _basketService.RemoveFromBasket(HttpContext, id);
            return RedirectToAction("Index");
        }

        public ActionResult BasketSummary()
        {
            var basketSummary = _basketService.GetBasketSummary(HttpContext);
            return PartialView(basketSummary);
        }

       
    }
}