using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Asp.netCoreMVC.Controllers
{
    public class CookiesController : Controller
    {
        public IActionResult Index()
        {
            // read Cookie
            string myName = Request.Cookies["myName"];
            return View("Index", myName);
            
        }

        [HttpPost]
        public IActionResult Index(IFormCollection form)
            {

            string myName = form["myName"].ToString();
            // set key value in cookie
            CookieOptions options = new CookieOptions();
            options.Expires = DateTime.Now.AddMinutes(5);
            Response.Cookies.Append("myName", myName, options);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult  DeleteCookie()
        {
            Response.Cookies.Delete("myName");
            return View("Index");

        }
    }
}