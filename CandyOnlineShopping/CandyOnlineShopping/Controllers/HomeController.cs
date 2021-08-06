using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CandyOnlineShopping.Models.Services.Interfaces;
using CandyOnlineShopping.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace CandyOnlineShopping.Controllers
{
    public class HomeController : Controller
    {
        private ICandyService _candyService;
        public HomeController(ICandyService candyService)
        {
            _candyService = candyService;
        }
        public IActionResult Index()
        {
            var homeViewModel = new HomeViewModel
            {
                CandyOnSale = _candyService.GetOnSale()
            } ;
            return View(homeViewModel);
        }
    }
}
