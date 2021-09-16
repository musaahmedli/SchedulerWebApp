using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLib
{
    public class Meeting
    {
        [Key]
        public int MeetingId { get; set; }
        public string Subject{ get; set; }
        [ForeignKey("Day")]
        public int DayId { get; set; }
        public virtual DayOfWeek Day{ get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public bool IsDeleted { get; set; }
        [ForeignKey("Project")]
        public int ProjectId { get; set; }
        public virtual Project Project { get; set; }
        public virtual List<EmployeeMeeting> EmployeeMeetings{ get; set; }
    }
}
