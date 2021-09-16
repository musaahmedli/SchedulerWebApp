using DTO.OrganizationDTOs;
using DTO.SectorDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchedulerMVC.Models
{
    public class SectorToUpdateViewModel
    {
        public SectorToUpdateDTO sector { get; set; }
        public List<DepartmentToListDTO> Departments { get; set; }
    }
}
