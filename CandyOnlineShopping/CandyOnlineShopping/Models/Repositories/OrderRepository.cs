using CandyOnlineShopping.Models.DataModels;
using CandyOnlineShopping.Models.Entity;
using CandyOnlineShopping.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CandyOnlineShopping.Models.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly AppDbContext _appDbContext;

        private readonly ShoppingCart _shoppingCart;

        public OrderRepository(AppDbContext appDbContext,ShoppingCart shoppingCart)
        {
            _appDbContext = appDbContext;
            _shoppingCart = shoppingCart;
        }
        public void CreateOrder(Order order)
        {
            order.OrderPlaced = DateTime.Now;
            order.Total = _shoppingCart.GetShoppingCartTotal();
            _appDbContext.Order.Add(order);
            _appDbContext.SaveChanges();

            var shoppingCartItems = _shoppingCart.GetShoppingCartItems();
            foreach(var cartItem in shoppingCartItems)
            {
                var orderDetail = new OrderDetail
                {
                    Quantity = cartItem.Amount,
                    Price = cartItem.Candy.Price,
                    CandyId = cartItem.Candy.Id,
                    OrderId = order.Id
                };
                _appDbContext.OrderDetail.Add(orderDetail);
            }

            _appDbContext.SaveChanges();
        }
    }
}
