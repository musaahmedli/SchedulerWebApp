using AutoMapper;
using BusinessLogicLib.IServices;
using DTO.EmployeeDTOs;
using DTO.MeetingDTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SchedulerMVC.Models.MeetingModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchedulerMVC.Controllers
{
    public class MeetingController : Controller
    {
        readonly IMeetingService _meetingService;

        readonly IEmployeeService employeeService;

        readonly IProjectService projectService;

        readonly IMapper _mapper;
        public MeetingController(IProjectService projectService, IEmployeeService employeeService, IMeetingService meetingService, IMapper mapper)
        {
            _meetingService = meetingService;

            this.projectService = projectService;

            _mapper = mapper;

            this.employeeService = employeeService;
        }
        public async Task<IActionResult> Index(int meetingDaysId, int employeeId)
        {
            MeetingViewModel meetingViewModel = new MeetingViewModel();

            meetingViewModel.Authorization = HttpContext.Session.GetString("Auth");

            if (meetingViewModel.Authorization == "true")
            {
                meetingViewModel.Meetings = await _meetingService.Get(meetingDaysId);
            }
            else
            {
                meetingViewModel.Meetings = await _meetingService.GetMeetingOfEmployee(employeeId, meetingDaysId);
            }
            return View(meetingViewModel);
        }

        public async Task<IActionResult> AddForm(int meetingDaysId)
        {
            MeetingToAddViewModel meetingToAddViewModel = new MeetingToAddViewModel();

            meetingToAddViewModel.Employees = await employeeService.Get();

            meetingToAddViewModel.Projects = await projectService.Get();

            MeetingToAddDTO meetingToAddDTOManual = new MeetingToAddDTO();

            meetingToAddDTOManual.MeetingDaysId = meetingDaysId;

            meetingToAddViewModel.meetingToAddDTO = meetingToAddDTOManual;

            return View(meetingToAddViewModel);
        }
        public async Task<IActionResult> Add(MeetingToAddViewModel meetingToAddViewModel)
        {
            if (meetingToAddViewModel.meetingToAddDTO.StartTime.ToString()==meetingToAddViewModel.meetingToAddDTO.EndTime.ToString())
            {
                return RedirectToAction("AddForm");
            }
            else
            {
                await _meetingService.Add(meetingToAddViewModel.meetingToAddDTO);

                return RedirectToAction("Index", "MeetingDays");
            }
            
        }

        public async Task<IActionResult> UpdateForm(int meetingId)
        {
            MeetingToUpdateViewModel meetingToUpdateViewModel = new MeetingToUpdateViewModel();

            meetingToUpdateViewModel.Meeting = _mapper.Map<MeetingToUpdateDTO>(await _meetingService.GetById(meetingId));

            meetingToUpdateViewModel.Projects = await projectService.Get();

            meetingToUpdateViewModel.Employees = await employeeService.Get();

            return View(meetingToUpdateViewModel);
        }

        public IActionResult Update(MeetingToUpdateViewModel meetingToUpdateViewModel)
        {
            _meetingService.Update(meetingToUpdateViewModel.Meeting);

            return RedirectToAction("Index", "Meeting");
        }

        public async Task<IActionResult> Delete(int meetingId)
        {
            await _meetingService.Delete(meetingId);

            return RedirectToAction("Index","Meeting");
        }    
            
    }
}
