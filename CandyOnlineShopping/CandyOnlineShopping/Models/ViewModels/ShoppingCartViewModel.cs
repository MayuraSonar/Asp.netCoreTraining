using CandyOnlineShopping.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CandyOnlineShopping.Models.ViewModels
{
    public class ShoppingCartViewModel
    {
        public List<ShoppingCartItem> ShoppingCart { get; set; }
        public decimal ShoppingCartTotal { get; set; }
    }
}
