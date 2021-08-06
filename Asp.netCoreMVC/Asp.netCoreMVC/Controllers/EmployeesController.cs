using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Asp.netCoreMVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace Asp.netCoreMVC.Controllers
{
    public class EmployeesController : Controller
    {
        public IActionResult Index()
        {
            List<Employee> employees = new List<Employee>();
            employees.Add(new Employee { id = 1, name = "Mayura", location = "Bangalore", department = "Technology" });
            employees.Add(new Employee { id = 2, name = "Sam", location = "USA", department = "Marketing" });
            employees.Add(new Employee { id = 3, name = "Anita", location = "Pune", department = "HR" });
            ViewBag.employeeDetails = employees;
            return View();
        }
    }
}