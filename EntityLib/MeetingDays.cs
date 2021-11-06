using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLib
{
    public class MeetingDays
    {
        [Key]
        public int MeetingDaysId { get; set; }
        public int MeetingWeekId { get; set; }
        public virtual MeetingWeek MeetingWeek { get; set; }
        public int DayId { get; set; }
        public virtual DaysOfWeek Days { get; set; }
    }
}
