using DTO.OrganizationDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchedulerMVC.Models
{
    public class DepartmentToUpdateViewModel
    {
        public DepartmentToUpdateDTO Department { get; set; }
        public List<OrganizationToListDTO> Organizations { get; set; }
    }
}
