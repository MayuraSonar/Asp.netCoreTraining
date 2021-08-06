using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Asp.netCoreMVC.Controllers
{
    public class TempDataController : Controller
    {
        public IActionResult Index()
        {
            TempData["message"] = "Message Coming from Tempdata!!";
            ViewData["message1"] = "Message Coming from ViewData!!";
            TempData.Keep("message");
            return View();
        }

        public IActionResult Aboutus()
        {
           TempData.Keep("message");
            return View();
            
        }

        public IActionResult Contact()
        {
            TempData.Keep("message");
            return View();
        }
    }
}