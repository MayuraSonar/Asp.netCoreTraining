using CandyOnlineShopping.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CandyOnlineShopping.Models.Interfaces
{
    
        public interface IShoppingCartItemRepository
        {
            void AddToCart(Candy candy, int amount, string shoppingCartId);
            void ClearCart(string shoppingCartId);
            List<ShoppingCartItem> GetShoppingCartItems(string shoppingCartId);
            decimal GetShoppingCartTotal(string shoppingCartId);
            int RemoveFromCart(Candy candy, string shoppingCartId);
        }
    }

