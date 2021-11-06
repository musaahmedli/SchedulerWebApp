using AutoMapper;
using BusinessLogicLib.IServices;
using DTO.ProjectDTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchedulerMVC.Models.ProjectModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchedulerMVC.Controllers
{
    public class ProjectController : Controller
    {
        private readonly IProjectService _service;
        private readonly IMapper _mapper;
        public ProjectController(IMapper mapper,IProjectService service)
        {
            _service = service;
            _mapper = mapper;
        }
        public async Task<IActionResult> Index()
        {
            ProjectViewModel projectViewModel = new ProjectViewModel();
            projectViewModel.Authorization = HttpContext.Session.GetString("Auth");
            projectViewModel.Projects = await _service.Get();
            return View(projectViewModel);
        }

        public IActionResult AddForm()
        {
            ProjectToAddViewModel projectToAddViewModel = new ProjectToAddViewModel();
            return View(projectToAddViewModel);
        }
        public async Task<IActionResult> Add(ProjectToAddViewModel projectToAddViewModel)
        {
            await _service.Add(projectToAddViewModel.Project);
            return RedirectToAction("Index", "Project");
        }

        public async Task<IActionResult> UpdateForm(int projectId)
        {
            ProjectToUpdateViewModel projectToUpdateViewModel = new ProjectToUpdateViewModel();
            projectToUpdateViewModel.Project = _mapper.Map<ProjectToUpdateDTO>(await _service.GetById(projectId));
            return View(projectToUpdateViewModel);
        }

        public IActionResult Update(ProjectToUpdateViewModel projectToUpdateViewModel)
        {
            _service.Update(projectToUpdateViewModel.Project);
            return RedirectToAction("Index","Project");
        }

        public async Task<IActionResult> Delete(int projectId)
        {
            await _service.Delete(projectId); 
            return RedirectToAction("Index", "Project");
        }
    }
}
