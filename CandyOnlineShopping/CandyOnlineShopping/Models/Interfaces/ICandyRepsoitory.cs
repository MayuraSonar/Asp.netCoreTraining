using CandyOnlineShopping.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CandyOnlineShopping.Models.Interfaces
{
  public  interface ICandyRepsoitory
    {

        IEnumerable<Candy> GetAll();
        IEnumerable<Candy> GetOnSale();
        Candy GetById(int candyId);
    }
}
