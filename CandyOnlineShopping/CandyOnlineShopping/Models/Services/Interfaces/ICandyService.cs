using CandyOnlineShopping.Models.Entity;
using CandyOnlineShopping.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CandyOnlineShopping.Models.Services.Interfaces
{
   public interface ICandyService
    {

        IEnumerable<Candy> GetAll();
        IEnumerable<Candy> GetOnSale();
        Candy GetById(int candyId);

    }
}
