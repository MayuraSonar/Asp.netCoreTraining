using CandyOnlineShopping.Models.Entity;
using CandyOnlineShopping.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CandyOnlineShopping.Components
{
    public class ShoppingCartSummary:ViewComponent
    {

        private readonly ShoppingCart _shoppingCart;

        public ShoppingCartSummary(ShoppingCart shoppingCart)
        {
            _shoppingCart = shoppingCart;
        }

        public IViewComponentResult Invoke()
        {
            var shoppingCartViewModel = new ShoppingCartViewModel

            {
                ShoppingCart = _shoppingCart.GetShoppingCartItems(),
                ShoppingCartTotal = _shoppingCart.GetShoppingCartTotal()
            };

            return View(shoppingCartViewModel);
        }
    }
}
