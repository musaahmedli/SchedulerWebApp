using DTO.OrganizationDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchedulerMVC.Models.OrganizationModels
{
    public class OrganizationToUpdateViewModel
    {
        public OrganizationToUpdateDTO Organization { get; set; }
        public List<OrganizationToListDTO> Organizations { get; set; }
    }
}
