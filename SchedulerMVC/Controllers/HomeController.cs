using BusinessLogicLib.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SchedulerMVC.Models.EmployeeModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
            
            return View(employeeLoginViewModel);
        }
        public async Task<IActionResult> Login(EmployeeLoginViewModel employeeLoginViewModel)
        {
            EmployeeLoginViewModel loginViewModel = new EmployeeLoginViewModel();

            loginViewModel.Employee = await _service.Login(employeeLoginViewModel.Employee);

            if (loginViewModel.Employee != null)
            {
                HttpContext.Session.SetString("EmployeeName", JsonConvert.SerializeObject(loginViewModel.Employee.Name));
                HttpContext.Session.SetString("EmployeeSurname", JsonConvert.SerializeObject(loginViewModel.Employee.Surname));
                HttpContext.Session.SetString("Auth",JsonConvert.SerializeObject(loginViewModel.Employee.IsAdmin));

                HttpContext.Session.SetInt32("Id", loginViewModel.Employee.EmployeeId);
                
                return RedirectToAction("Index","Organization");
            }
            return RedirectToAction("LoginForm");
        }

        public IActionResult Logout()
        {
            HttpContext.Session = null;

            return RedirectToAction("LoginForm");
        }
        
    }
}
