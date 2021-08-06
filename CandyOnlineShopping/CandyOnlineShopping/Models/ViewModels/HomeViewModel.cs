using CandyOnlineShopping.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CandyOnlineShopping.Models.ViewModels
{
    public class HomeViewModel
    {
       public IEnumerable<Candy> CandyOnSale { get; set; }
    }
}
