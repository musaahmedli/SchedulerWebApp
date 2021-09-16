using BusinessLogicLib.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SchedulerMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace SchedulerMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly IEmployeeService _service;
        public HomeController(IEmployeeService service)
        {
            _service = service;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult LoginForm()
        {
            EmployeeLoginViewModel employeeLoginViewModel = new EmployeeLoginViewModel();
            HttpContext.Session.SetString("IsAdmin",JsonConvert.SerializeObject(employeeLoginViewModel.Employee.IsAdmin));
            return View(employeeLoginViewModel);
        }
        public async Task<IActionResult> Login(EmployeeLoginViewModel employeeLoginViewModel)
        {
            if (await _service.Login(employeeLoginViewModel.Employee))
            {
                return View("MainPage");
            }
            return View("LoginForm");
        }

    }
}
