using BusinessLogicLib.IServices;
using DataAccessLib.IRepositories;
using DTO.MeetingDays;
using DTO.MeetingWeek;
using EntityLib;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchedulerMVC.Models.MeetingWeekModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchedulerMVC.Controllers
{
    public class MeetingDaysController : Controller
    {
        readonly IMeetingDaysService meetingDaysService;
        readonly IMeetingWeekService meetingWeekService;
        public MeetingDaysController(IMeetingDaysService meetingDaysService,IMeetingWeekService meetingWeekService)
        {
            this.meetingDaysService = meetingDaysService;
            this.meetingWeekService = meetingWeekService;
        }

        public async Task<IActionResult> Index()
        {
            MeetingWeekViewModel weekModel = new MeetingWeekViewModel();
            weekModel.Authorization = HttpContext.Session.GetString("Auth");
            weekModel.EmployeeId = (int)HttpContext.Session.GetInt32("Id");
            weekModel.MeetingWeek = await meetingWeekService.GetActiveWeekDays();
            return View(weekModel);
        }

        public async Task<IActionResult> SeeArchive()
        {
            ArchiveWeekModel archiveWeek = new ArchiveWeekModel();
            archiveWeek.EmployeeId = (int)HttpContext.Session.GetInt32("Id");
            archiveWeek.archiveWeeks = await meetingWeekService.SeeArchive();
            return View(archiveWeek);
        }
    }
}
