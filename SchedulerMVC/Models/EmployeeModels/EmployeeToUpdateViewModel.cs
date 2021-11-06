using DTO.EmployeeDTOs;
using DTO.PositionDTOs;
using DTO.SectorDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchedulerMVC.Models.EmployeeModels
{
    public class EmployeeToUpdateViewModel
    {
        public EmployeeToUpdateDTO Employee { get; set; }
        public List<SectorToListDTO> Sectors { get; set; }
        public List<PositionToListDTO> Positions { get; set; }
    }
}
