using DTO.OrganizationDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchedulerMVC.Models.OrganizationModels
{
    public class OrganizationViewModel
    {
        public List<OrganizationToListDTO> Organizations { get; set; }
        public string Authorization { get; set; }
    }
}
