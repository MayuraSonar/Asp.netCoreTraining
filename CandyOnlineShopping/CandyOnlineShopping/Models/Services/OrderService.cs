using CandyOnlineShopping.Models.Entity;
using CandyOnlineShopping.Models.Interfaces;
using CandyOnlineShopping.Models.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CandyOnlineShopping.Models.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;

        public OrderService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }
        public void CreateOrder(Order order)
        {
            _orderRepository.CreateOrder(order);
        }
    }
}
