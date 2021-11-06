using DTO.OrganizationDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchedulerMVC.Models.DepartmentModels
{
    public class DepartmentViewModel
    {
        public List<DepartmentToListDTO> Departments { get; set; }
        public string Authorization { get; set; }
    }
}
