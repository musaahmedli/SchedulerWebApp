using DTO.EmployeeDTOs;
using DTO.MeetingDTOs;
using DTO.ProjectDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchedulerMVC.Models.MeetingModels
{
    public class MeetingToUpdateViewModel
    {
        public MeetingToUpdateDTO Meeting { get; set; }
        public List<EmployeeToListDTO> Employees { get; set; }
        public List<ProjectToListDTO> Projects { get; set; }

    }
}
