using DTO.EmployeeDTOs;
using DTO.MeetingDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.EmployeeMeetingDTOs
{
    public class EmployeeMeetingToListDTO
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public  EmployeeToListDTO Employee { get; set; }
        public int MeetingId { get; set; }
        public MeetingToListDTO Meeting { get; set; }
    }
}
