using CandyOnlineShopping.Models.DataModels;
using CandyOnlineShopping.Models.Entity;
using CandyOnlineShopping.Models.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CandyOnlineShopping.Models.Repositories
{
    public class CandyRepository : ICandyRepsoitory
    {
        //private readonly ICategoryRepository _categoryRepository;

        private readonly AppDbContext _appDbContext;
        public CandyRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public IEnumerable<Candy> GetAll()
        {
            //List<Candy> candies = new List<Candy>()
            //    {
            //        new Candy{Id=1,Name="Assorted Hard Candy",Price=45.4M,Description="Assorted Hardy Candy",Category=_categoryRepository.GetAll().ToList()[0],
            //            ImageUrl="\\Images\\hardCandy.jpg",IsInStock=true,IsOnSale=false,ImageThumbnailUrl="\\Images\\thumbnail\\hardCandy-small.jpg"
            //    },

            //        new Candy { Id=2,Name="Assorted Chocalate Candy",Price=5.95M,Description="Assorted Chocalte Candy",Category=_categoryRepository.GetAll().ToList()[1],ImageUrl="\\Images\\chocolateCandy.jpg",IsInStock=true,IsOnSale=false,ImageThumbnailUrl= "\\Images\\thumbnail\\chocolateCandy-small.jpg" },

            //         new Candy { Id=2,Name="Assorted Fruit Candy",Price=3.95M,Description="Assorted Fruit Candy",Category=_categoryRepository.GetAll().ToList()[2],ImageUrl="\\Images\\FruitCandy.jpg",IsInStock=true,IsOnSale=false,ImageThumbnailUrl= "\\Images\\thumbnail\\FruitCandy-small.jpg" }
            //};
            //return candies;

            return _appDbContext.Candy.Include(c => c.Category);
        }

        public Candy GetById(int candyId)
        {
            //return GetAll().FirstOrDefault(c => c.Id == candyId);
            // return _appDbContext.Candy.FirstOrDefault(c => c.Id == candyId);
            return _appDbContext.Candy.Include(c => c.Category).FirstOrDefault(c => c.Id == candyId);
            
        }

        public IEnumerable<Candy> GetOnSale()
        {
            return _appDbContext.Candy.Include(c => c.Category).Where(p => p.IsOnSale);
        }
    }
}
