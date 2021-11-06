using AutoMapper;
using BusinessLogicLib.IServices;
using DTO.SectorDTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchedulerMVC.Models.SectorModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchedulerMVC.Controllers
{
    public class SectorController : Controller
    {
        private readonly ISectorService _service;
        private readonly IDepartmentService _departmentService;
        private readonly IMapper _mapper; 
        public SectorController(IDepartmentService departmentService,IMapper mapper,ISectorService service)
        {
            _service = service;
            _mapper = mapper;
            _departmentService = departmentService;
        }
        public async Task<IActionResult> Index()
        {
            SectorViewModel sectorViewModel = new SectorViewModel();
            sectorViewModel.Authorization = HttpContext.Session.GetString("Auth");
            sectorViewModel.sectors = await _service.Get();
            return View(sectorViewModel);
        }

        public async Task<IActionResult> AddForm()
        {
            SectorToAddViewModel sectorToAddViewModel = new SectorToAddViewModel();
            sectorToAddViewModel.Departments = await _departmentService.Get();
            return View(sectorToAddViewModel);
        }
        public async Task<IActionResult> Add(SectorToAddViewModel sectorToAddViewModel)
        {
            await _service.Add(sectorToAddViewModel.Sector);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> UpdateForm(int sectorId)
        {
            SectorToUpdateViewModel sectorToUpdateViewModel = new SectorToUpdateViewModel();
            sectorToUpdateViewModel.sector = _mapper.Map<SectorToUpdateDTO>( await _service.GetById(sectorId));
            sectorToUpdateViewModel.Departments = await _departmentService.Get();
            return View(sectorToUpdateViewModel);
        }

        public IActionResult Update(SectorToUpdateViewModel sectorToUpdateViewModel)
        {
            _service.Update(sectorToUpdateViewModel.sector);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Delete(int sectorId)
        {
            await _service.Delete(sectorId);
            return RedirectToAction("Index");
        }
        
    }
}
