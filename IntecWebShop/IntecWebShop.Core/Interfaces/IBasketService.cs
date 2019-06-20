﻿using IntecWebShop.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace IntecWebShop.Core.Interfaces
{
    public interface IBasketService
    {
        void AddToBasket(HttpContextBase httpContext, string productId);

        void RemoveFromBasket(HttpContextBase httpContext, string itemId);

        List<BasketItemViewModel> GetBasketItems(HttpContextBase httpContext);

        BasketSummaryViewModel GetBasketSummary(HttpContextBase httpContext);
    }
}
