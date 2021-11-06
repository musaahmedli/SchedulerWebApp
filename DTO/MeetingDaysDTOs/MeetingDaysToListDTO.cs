using DTO.DaysOfWeekDTOs;
using DTO.MeetingWeek;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.MeetingDays
{
    public class MeetingDaysToListDTO
    {
        public int MeetingDaysId { get; set; }
        public int DayId { get; set; }
        public DaysOfWeekToListDTO Days { get; set; }
        public int MeetingWeekId { get; set; }
        public MeetingWeekToListDTO MeetingWeek{ get; set; }
    }
}
