using DTO.MeetingWeek;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchedulerMVC.Models.MeetingWeekModels
{
    public class ArchiveWeekModel
    {
        public List<MeetingWeekToListDTO> archiveWeeks { get; set; }
        public int EmployeeId { get; set; }
    }
}
