using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Asp.netCoreMVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace Asp.netCoreMVC.Controllers
{
    public class EmployeesInforViewModelController : Controller
    {
        public IActionResult Index()
        {
            Employee emp = new Employee()
            {
                id = 1,
                name = "Mayura",
                location = "Bangalore",
                department = "Technology"
            };

            EmployeeDetails empdetails = new EmployeeDetails()
            {
                id = 45,
                city = "Bangalore",
                state = "Karnataka",
                country = "India"
            };

            EmployeeInfoViewModel employeeInfoViewModel = new EmployeeInfoViewModel()
            {
                employee = emp,
                employeeDetails = empdetails,
                title = "Employee Information Page",
                footer = "CopyRight @Euromonitor!!!"
            };
            return View(employeeInfoViewModel);
        }
    }
}