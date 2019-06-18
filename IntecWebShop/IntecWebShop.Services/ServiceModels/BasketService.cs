using IntecWebShop.Core.Interfaces;
using IntecWebShop.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace IntecWebShop.Services.ServiceModels
{
    public class BasketService
    {
        IRepository<Product> _productContext;
        IRepository<Basket> _basketContext;

        public const string basketSessionName = "eCommerceBasket";

        public BasketService(IRepository<Product> productRepository, IRepository<Basket> basketRepository)
        {
            _productContext = productRepository;
            _basketContext = basketRepository;
        }

        private Basket GetBasket(HttpContextBase httpContext, bool createIfNull)
        {
            HttpCookie cookie = httpContext.Request.Cookies.Get(basketSessionName);

            Basket basket = new Basket();

            if (cookie != null)
            {
                var basketId = cookie.Value;

                if (!string.IsNullOrWhiteSpace(basketId))
                {
                    basket = _basketContext.FindInList(basketId);
                }
                else
                {
                    if (createIfNull)
                    {
                        basket = CreateNewBasket(httpContext);
                    }
                }
            }
            else
            {
                basket = CreateNewBasket(httpContext);
            }
            return basket;
        }

        private Basket CreateNewBasket(HttpContextBase httpContext)
        {
            var basket = new Basket();
            _basketContext.Insert(basket);
            _basketContext.Commit();

            HttpCookie cookie = new HttpCookie(basketSessionName);
            cookie.Value = basket.Id;

            cookie.Expires = DateTime.Now.AddDays(2);

            return basket;
        }

        public void AddToBasket(HttpContextBase httpContext, string productId)
        {
            Basket basket = GetBasket(httpContext, true);
            BasketItem item = basket.BasketItems.FirstOrDefault(x => x.ProductId == productId);

            if (item == null)
            {
                item = new BasketItem()
                {
                    BasketId = basket.Id,
                    ProductId = productId,
                    Quantity = 1
                };

                basket.BasketItems.Add(item);
            }
            else
            {
                item.Quantity++;
            }
            _basketContext.Commit();
        }

        public void RemoveFromBasket()
        {

        }
    }
}
