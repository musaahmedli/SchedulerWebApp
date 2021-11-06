using AutoMapper;
using BusinessLogicLib.IServices;
using DTO.PositionDTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchedulerMVC.Models.PositionModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchedulerMVC.Controllers
{
    public class PositionController : Controller
    {
        private readonly IPositionService _service;
        private readonly IMapper _mapper;
        public PositionController(IPositionService service,IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            PositionViewModel positionViewModel = new PositionViewModel();
            if (HttpContext.Session == null)
            {
                return BadRequest();
            }
            positionViewModel.Authorization = HttpContext.Session.GetString("Auth");
            positionViewModel.Positions = await _service.Get();
            return View(positionViewModel);
        }


        public IActionResult AddForm()
        {
            PositionToAddViewModel positionToAddViewModel = new PositionToAddViewModel();
            return View(positionToAddViewModel);
        }

        public async Task<IActionResult> Add(PositionToAddViewModel positionToAddViewModel)
        {
            await _service.Add(positionToAddViewModel.Position); 
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int positionId)
        {
            await _service.Delete(positionId);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> UpdateForm(int positionId)
        {
            PositionToUpdateViewModel positionToUpdateViewModel = new PositionToUpdateViewModel();
            positionToUpdateViewModel.Position = _mapper.Map<PositionToUpdateDTO>(await _service.GetById(positionId));
            return View(positionToUpdateViewModel);
        }

        public IActionResult Update(PositionToUpdateViewModel positionToUpdateViewModel)
        {
            _service.Update(positionToUpdateViewModel.Position);
            return RedirectToAction("Index");
        }
    }
}
