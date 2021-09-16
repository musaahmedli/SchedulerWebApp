using DTO.OrganizationDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchedulerMVC.Models
{
    public class OrganizationToAddViewModel
    {
        public OrganizationToAddDTO organizationToAdd { get; set; }
        public List<OrganizationToListDTO> Organizations { get; set;  }
    }
}
