using DTO.ProjectDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchedulerMVC.Models.ProjectViewModel
{
    public class ProjectViewModel
    {
        public List<ProjectToListDTO> Projects { get; set; }
    }
}
