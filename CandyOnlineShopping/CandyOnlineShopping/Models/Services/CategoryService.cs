using CandyOnlineShopping.Models.Entity;
using CandyOnlineShopping.Models.Interfaces;
using CandyOnlineShopping.Models.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CandyOnlineShopping.Models.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryReposiotry;
        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryReposiotry = categoryRepository;
        }
        public IEnumerable<Category> GetAll()
        {
            return _categoryReposiotry.GetAll();
        }
    }
}
