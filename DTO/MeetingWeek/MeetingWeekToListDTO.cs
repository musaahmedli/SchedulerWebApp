using DTO.MeetingDays;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.MeetingWeek
{
    public class MeetingWeekToListDTO
    {
        public int MeetingWeekId { get; set; }
        public DateTime StartDate{ get; set; }
        public DateTime EndDate { get; set; }
        public List<MeetingDaysToListDTO>  MeetingDays{ get; set; }
    }
}
