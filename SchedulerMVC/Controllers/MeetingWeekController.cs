using BusinessLogicLib.IServices;
using DTO.MeetingDTOs;
using DTO.MeetingWeek;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchedulerMVC.Controllers
{
    public class MeetingWeekController : Controller
    {
        readonly IMeetingWeekService meetingService;
        public MeetingWeekController(IMeetingWeekService meetingService)
        {
            this.meetingService= meetingService;
        }
        public async Task<IActionResult> StartWeekForm()
        {
            if (await meetingService.AnyIsActiveWeek() == false)
            {
                return View();
            }
            return RedirectToAction("Index", "MeetingDays");

        }

        public async Task<IActionResult> StartWeek(MeetingWeekToAddDTO meetingWeek)
        {
            await meetingService.Open(meetingWeek);
            return RedirectToAction("Index","MeetingDays");
        }

        public async Task<IActionResult> EndWeek()
        {
            await meetingService.Close();
            return RedirectToAction("Index","MeetingDays");
        }
    }
}
