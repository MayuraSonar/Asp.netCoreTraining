using CandyOnlineShopping.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CandyOnlineShopping.Models.ViewModels
{
    public class CandyListViewModel
     {
        public string CurrentCategory { get; set; }
        public IEnumerable<Candy> Candies;

    }
}
