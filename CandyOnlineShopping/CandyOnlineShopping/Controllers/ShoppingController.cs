using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CandyOnlineShopping.Models.Entity;
using CandyOnlineShopping.Models.Interfaces;
using CandyOnlineShopping.Models.Services.Interfaces;
using CandyOnlineShopping.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace CandyOnlineShopping.Controllers
{
    public class ShoppingController : Controller
    {
        private readonly ICandyService _candyService;
        private readonly ShoppingCart _shoppingCart;

        public ShoppingController(ICandyService candyService,ShoppingCart shoppingCart)
        {
            _candyService = candyService;
            _shoppingCart = shoppingCart;

            }

        
        public IActionResult Index()
        {
            
            var shoppingCartViewModel = new ShoppingCartViewModel
            {
                ShoppingCart = _shoppingCart.GetShoppingCartItems(),
            ShoppingCartTotal = _shoppingCart.GetShoppingCartTotal()
            };
            return View(shoppingCartViewModel);
        }

        public RedirectToActionResult AddToShoppingCart(int candyId)
        {
            var selectedCandy = _candyService.GetAll().FirstOrDefault(c => c.Id == candyId);
            if(selectedCandy!=null)
            {
                _shoppingCart.AddToCart(selectedCandy, 1);
            }

            return RedirectToAction("Index");
        }

        public RedirectToActionResult ClearCart()
        {
            _shoppingCart.ClearCart();
            return RedirectToAction("Index");
        }

        public RedirectToActionResult RemoveFromShoppingCart(int candyId)
        {
            var selectedCandy = _candyService.GetAll().FirstOrDefault(c => c.Id == candyId);
            if (selectedCandy != null)
            {
                _shoppingCart.RemoveFromCart(selectedCandy);
            }
            return RedirectToAction("Index");
        }
    }
}
