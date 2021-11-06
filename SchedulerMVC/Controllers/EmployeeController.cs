using AutoMapper;
using BusinessLogicLib.IServices;
using DTO.EmployeeDTOs;
using DTO.OrganizationDTOs;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchedulerMVC.Models.EmployeeModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace SchedulerMVC.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeService _service;

        private readonly ISectorService _sectorService;

        private readonly IPositionService _positionService;

        private readonly IOrganizationService _organizationService;

        private readonly IDepartmentService _departmentService;

        private readonly IMapper _mapper;

        private readonly IWebHostEnvironment _hostEnvironment;
        public EmployeeController(IOrganizationService organizationService,IDepartmentService departmentService, IEmployeeService service, IMapper mapper, ISectorService sectorService, IPositionService positionService, IWebHostEnvironment hostEnvironment)
        {
            _service = service;

            _mapper = mapper;

            _sectorService = sectorService;

            _positionService = positionService;

            _hostEnvironment = hostEnvironment;

            _departmentService = departmentService;

            _organizationService = organizationService;

        }
        public async Task<IActionResult> Index()
        {
            EmployeeViewModel employeeViewModel = new EmployeeViewModel();

            employeeViewModel.Authorization = HttpContext.Session.GetString("Auth");

            employeeViewModel.Employees = await _service.Get();

            return View(employeeViewModel);
        }

        public async Task<IActionResult> AddForm()
        {
            EmployeeToAddViewModel employeeToAddViewModel = new EmployeeToAddViewModel();

            //employeeToAddViewModel.Sectors = await _sectorService.Get();

            employeeToAddViewModel.Positions = await _positionService.Get();

            employeeToAddViewModel.Organizations = await _organizationService.Get();
            
            return View(employeeToAddViewModel);
        }

        public async Task<IActionResult> Add(EmployeeToAddViewModel employeeToAddViewModel)
        {
            if (employeeToAddViewModel.Employee.Image != null)
            {
                string root = _hostEnvironment.WebRootPath;

                string fileName = Path.GetFileName(employeeToAddViewModel.Employee.Image.FileName);

                employeeToAddViewModel.Employee.ImagePath = fileName;

                string fullPath = Path.Combine(root + "/images/", fileName);

                using (var stream = new FileStream(fullPath, FileMode.Create))
                {
                    await employeeToAddViewModel.Employee.Image.CopyToAsync(stream);
                }
            }
            await _service.Add(employeeToAddViewModel.Employee);

            return RedirectToAction("LoginForm", "Home");
        }

        public async Task<IActionResult> UpdateForm(int employeeId)
        {
            EmployeeToUpdateViewModel employeeToUpdateViewModel = new EmployeeToUpdateViewModel();

            employeeToUpdateViewModel.Employee = _mapper.Map<EmployeeToUpdateDTO>(await _service.GetById(employeeId));

            employeeToUpdateViewModel.Sectors = await _sectorService.Get();

            employeeToUpdateViewModel.Positions = await _positionService.Get();

            return View(employeeToUpdateViewModel);
        }

        public async Task<IActionResult> Update(EmployeeToUpdateViewModel employeeToUpdateViewModel)
        {
            if (employeeToUpdateViewModel.Employee.Image != null)
            {
                string root = _hostEnvironment.WebRootPath;

                string fileName = Path.GetFileName(employeeToUpdateViewModel.Employee.Image.FileName);

                employeeToUpdateViewModel.Employee.ImagePath = fileName;

                string fullPath = Path.Combine(root + "/images/", fileName);

                using (var stream = new FileStream(fullPath, FileMode.Create))
                {
                    await employeeToUpdateViewModel.Employee.Image.CopyToAsync(stream);
                }
            }
            _service.Update(employeeToUpdateViewModel.Employee);

            return RedirectToAction("Index", "Employee");
        }

        public async Task<IActionResult> Delete(int employeeId)
        {
            await _service.Delete(employeeId);

            return RedirectToAction("Index", "Employee");
        }

        public async Task<IActionResult> GetEmployeesOfMeeting(int meetingId)
        {
            EmployeeViewModel employeeViewModel = new EmployeeViewModel();

            employeeViewModel.Employees = await _service.GetEmployeesOfMeeting(meetingId);

            return View(employeeViewModel);
        }

        public async Task<JsonResult> GetDepartmentsByOrganization(int organizationId)
        {
            List<DepartmentToListDTO> departments = await _departmentService.GetDepartmentsByOrganization(organizationId);
            return Json(departments);
        }

        public async Task<JsonResult> GetSectorsByDepartment(int departmentId)
        {
            return Json(await _sectorService.GetSectorByDepartment(departmentId));
        }
    }
}
