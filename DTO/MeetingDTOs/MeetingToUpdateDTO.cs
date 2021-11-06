using DTO.ProjectDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.MeetingDTOs
{
    public class MeetingToUpdateDTO
    {
        public int MeetingId { get; set; }
        public string Subject { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public int ProjectId { get; set; }
        public  ProjectToListDTO Project { get; set; }
        public List<int> EmployeeIdList { get; set; }
        public int MeetingDaysId { get; set; }
    }
}
