using AutoMapper;
using BusinessLogicLib.IServices;
using DTO.OrganizationDTOs;
using Microsoft.AspNetCore.Mvc;
using SchedulerMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchedulerMVC.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly IDepartmentService _service;
        private readonly IOrganizationService _OrganizationService;
        private readonly IMapper _mapper;
        public DepartmentController(IDepartmentService service,IMapper mapper, IOrganizationService organizationService)
        {
            _service = service;
            _mapper = mapper;
            _OrganizationService = organizationService;
        }
        public async Task<IActionResult> Index()
        {
            DepartmentViewModel departmentViewModel = new DepartmentViewModel();
            departmentViewModel.Departments = await _service.Get();
            return View(departmentViewModel);
        }
        public async Task<IActionResult> AddForm()
        {
            DepartmentToAddViewModel departmentToAddViewModel = new DepartmentToAddViewModel();
            departmentToAddViewModel.Organizations = await _OrganizationService.Get();
            return View(departmentToAddViewModel);
        }
        public IActionResult Add(DepartmentToAddViewModel departmentToAddViewModel)
        {
            _service.Add(departmentToAddViewModel.Department);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> UpdateForm(int departmentId)
        {
            DepartmentToUpdateViewModel departmentToUpdateViewModel = new DepartmentToUpdateViewModel();
            departmentToUpdateViewModel.Department = _mapper.Map<DepartmentToUpdateDTO>(await _service.GetById(departmentId));
            departmentToUpdateViewModel.Organizations =await _OrganizationService.Get();
            return View(departmentToUpdateViewModel);
        }
        public IActionResult Update(DepartmentToUpdateViewModel departmentToUpdateViewModel)
        {
            _service.Update(departmentToUpdateViewModel.Department);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Delete(int departmentId)
        {
            await _service.Delete(departmentId);
            return RedirectToAction("Index");
        }
     
    }
}
