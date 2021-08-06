using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CandyOnlineShopping.Models.Entity;
using CandyOnlineShopping.Models.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CandyOnlineShopping.Controllers
{
    [Authorize]
    public class OrderController : Controller
    {
        private readonly IOrderService _orderService;

        private readonly ShoppingCart _shoppingCart;

        public OrderController(IOrderService orderService,ShoppingCart shoppingCart)
        {
            _orderService = orderService;
            _shoppingCart = shoppingCart;
        }


        public IActionResult Checkout()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Checkout(Order order)
        {
            var s = _shoppingCart.GetShoppingCartItems();
            if(s.Count==0)
            {
                ModelState.AddModelError("", "Your Cart is Empty!! Please add items to perform checkout");
            }
            else if(ModelState.IsValid)
            {
                _orderService.CreateOrder(order);
                _shoppingCart.ClearCart();
                return RedirectToAction("CheckoutComplete");
            }

            return View(order);
        }

        public IActionResult CheckoutComplete()
        {
            ViewBag.CheckoutMessage = "Thank you for Order!! Enjoy your Candies!!";
            return View();
        }
    }
}
