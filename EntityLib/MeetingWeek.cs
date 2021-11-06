using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLib
{
    public class MeetingWeek
    {
        [Key]
        public int MeetingWeekId { get; set; }
        public DateTime StartDate { get; set; } 
        public DateTime EndDate { get; set; }
        public bool IsActive { get; set; } = true;
        public virtual List<MeetingDays> MeetingDays { get; set; }
    }
}
