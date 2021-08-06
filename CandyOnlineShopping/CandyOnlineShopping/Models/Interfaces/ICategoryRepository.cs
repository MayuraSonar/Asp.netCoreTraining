using CandyOnlineShopping.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CandyOnlineShopping.Models.Interfaces
{
   public interface ICategoryRepository
    {
        IEnumerable<Category> GetAll();
    }
}
