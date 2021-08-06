using CandyOnlineShopping.Models.Entity;
using CandyOnlineShopping.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CandyOnlineShopping.Models.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        public IEnumerable<Category> GetAll()
        {
            List<Category> categories = new List<Category>()
            {
                new Category{Id=1,Name="Hard Candy", Description="Awesome and Delicious Hard Candy"},
                new Category{Id=2,Name="Chocolate Candy", Description="Chocalate Candy"},
                new Category{Id=3,Name="Fruit Candy",Description="Sweet and Sour Fruit Candy"}
            };
            return categories;
        }
    }
}
