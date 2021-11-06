using DTO.OrganizationDTOs;
using DTO.SectorDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchedulerMVC.Models.SectorModels
{
    public class SectorToAddViewModel
    {
        public SectorToAddDTO Sector { get; set; }
        public List<DepartmentToListDTO> Departments { get; set; }
    }
}
