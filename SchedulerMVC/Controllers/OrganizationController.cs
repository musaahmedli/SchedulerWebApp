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
    public class OrganizationController : Controller
    {
        private readonly IOrganizationService _service;
        private readonly IMapper _mapper;
        public OrganizationController(IOrganizationService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        //All Organizations
        public async Task<IActionResult> Index()
        {
            OrganizationViewModel organizationViewModel = new OrganizationViewModel();
            organizationViewModel.Organizations = await _service.Get();
            
            return View(organizationViewModel);
        }

        //Opening Form For Adding Organization
        public async Task<IActionResult> AddForm()
        {
            OrganizationToAddViewModel organizationToAddViewModel = new OrganizationToAddViewModel();
            organizationToAddViewModel.Organizations = await _service.Get();
            return View(organizationToAddViewModel);
        }

        //Adding Organization
        public async Task<IActionResult> Add(OrganizationToAddViewModel organizationToAddViewModel)
        {
            await _service.Add(organizationToAddViewModel.organizationToAdd);
            return RedirectToAction("Index");
        }

        //Opening Form For Updating Organization
        public async Task<IActionResult> UpdateForm(int organizationId)
        {
            OrganizationToUpdateViewModel organizationToUpdateViewModel = new OrganizationToUpdateViewModel();
            organizationToUpdateViewModel.Organization = _mapper.Map<OrganizationToUpdateDTO>(await _service.GetById(organizationId));
            organizationToUpdateViewModel.Organizations = await _service.Get();
            return View(organizationToUpdateViewModel);
        }

        //Updating Organization
        public IActionResult Update(OrganizationToUpdateViewModel organizationToUpdate)
        {
            _service.Update(organizationToUpdate.Organization);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Delete(int organizationId)
        {
            await _service.Delete(organizationId);
            return RedirectToAction("Index");
        }

    }
}
