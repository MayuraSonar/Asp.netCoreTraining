using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CandyOnlineShopping.Models.Entity;
using CandyOnlineShopping.Models.Services.Interfaces;
using CandyOnlineShopping.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace CandyOnlineShopping.Controllers
{
    public class CandyController : Controller
    {
        private readonly ICandyService _candyService;
        private readonly ICategoryService _categoryService;

        public CandyController(ICandyService candyService,ICategoryService categoryService)
        {
            _candyService = candyService;
            _categoryService = categoryService;
        }
        //public IActionResult List()
        //{

        //    var candyListViewModel = new CandyListViewModel();
        //    candyListViewModel.CurrentCategory = "Best Sellers!!";
        //    candyListViewModel.Candies = _candyService.GetAll();
        //    //ViewBag.CurrentCategory = "Best Sellers!!!";
        //    //return View(_candyService.GetAll());
        //    return View(candyListViewModel);
        //}

        public ViewResult List(string category)
        {
            IEnumerable<Candy> candies;

            string currentCategory;
            if(string.IsNullOrEmpty(category))
            {
                candies = _candyService.GetAll().OrderBy(c => c.Id);
                currentCategory = "All Candies";
            }

            else
            {
                candies = _candyService.GetAll().
                    Where(c => c.Category.Name == category);
                currentCategory = _candyService.GetAll().
                    FirstOrDefault(c => c.Category.Name == category).Name;
            }

            return View(new CandyListViewModel
            {
                Candies = candies,
                CurrentCategory = currentCategory

            });

        }

        public IActionResult Details(int id)
        {
            var candy = _candyService.GetById(id);
            if (candy == null)
            {
                return NotFound();
            }

            return View(candy);
        }
    }
}