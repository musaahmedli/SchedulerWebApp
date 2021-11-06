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
        [Required]
        public string Subject { get; set; }
        [Required]
        public DateTime StartTime { get; set; }
        [Required]
        public DateTime EndTime { get; set; }
        public bool IsDeleted { get; set; }
        [ForeignKey("Project")]
        public int ProjectId { get; set; }
        public virtual Project Project { get; set; }
        [NotMapped]
        [Required]
        public  List<int> EmployeeIdList { get; set; }
        public virtual List<EmployeeMeeting> EmployeeMeetings { get; set; }
        public int MeetingDaysId { get; set; }
        public virtual MeetingDays MeetingDay{get;set;}
    }
}
