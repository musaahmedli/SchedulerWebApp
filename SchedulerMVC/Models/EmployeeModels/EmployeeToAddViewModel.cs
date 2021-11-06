using DTO.EmployeeDTOs;
using DTO.OrganizationDTOs;
using DTO.PositionDTOs;
using DTO.SectorDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchedulerMVC.Models.EmployeeModels
{
    public class EmployeeToAddViewModel
    {
        public EmployeeToAddDTO Employee { get; set; }
        public List<SectorToListDTO> Sectors { get; set; }
        public List<PositionToListDTO> Positions { get; set; }
        public List<OrganizationToListDTO> Organizations { get; set; }
        public List<DepartmentToListDTO> Departments { get; set; }
    }
}
