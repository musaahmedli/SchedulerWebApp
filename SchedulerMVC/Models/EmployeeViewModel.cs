using DTO.EmployeeDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchedulerMVC.Models
{
    public class EmployeeViewModel
    {
        public List<EmployeeToListDTO> Employees { get; set; }
    }
}
