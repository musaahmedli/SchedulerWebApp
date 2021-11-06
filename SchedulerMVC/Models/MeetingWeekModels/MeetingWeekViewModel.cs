using DTO.MeetingWeek;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchedulerMVC.Models.MeetingWeekModels
{
    public class MeetingWeekViewModel
    {
        public MeetingWeekToListDTO MeetingWeek { get; set; }
        public string Authorization { get; set; }
        public int EmployeeId { get; set; }
    }
}
