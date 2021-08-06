using CandyOnlineShopping.Models.DataModels;
using CandyOnlineShopping.Models.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CandyOnlineShopping.Models.Entity
{
    public class ShoppingCart
    {

        private readonly IShoppingCartItemRepository _shoppingCartItemRepository;

        public ShoppingCart(IShoppingCartItemRepository shoppingCartItemRepository)
        {
            _shoppingCartItemRepository = shoppingCartItemRepository;
        }

        [Column("ShoppingCartId")]
        public string Id { get; set; }
        public List<ShoppingCartItem> ShoppingCartItems { get; set; }

        public void AddToCart(Candy candy, int amount)
        {
            _shoppingCartItemRepository.AddToCart(candy, amount, Id);
        }

        public void ClearCart()
        {
            _shoppingCartItemRepository.ClearCart(Id);
        }

        public static ShoppingCart GetCart(IServiceProvider services)
        {
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?
                .HttpContext.Session;

            var context = services.GetService<IShoppingCartItemRepository>();
            string shoppingCartId = session.GetString("ShoppingCartId") ?? Guid.NewGuid().ToString();

            session.SetString("ShoppingCartId", shoppingCartId);

            return new ShoppingCart(context) { Id = shoppingCartId };
        }

        public List<ShoppingCartItem> GetShoppingCartItems()
        {
            return _shoppingCartItemRepository.GetShoppingCartItems(Id);
        }

        public decimal GetShoppingCartTotal()
        {
            return _shoppingCartItemRepository.GetShoppingCartTotal(Id);
        }

        public int RemoveFromCart(Candy candy)
        {
            return _shoppingCartItemRepository.RemoveFromCart(candy, Id);
        }
    }

}


