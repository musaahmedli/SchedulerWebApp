using DTO.OrganizationDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.SectorDTOs
{
    public class SectorToListDTO
    {
        public int SectorId { get; set; }
        public string Name { get; set; }
        public int DepartmentId { get; set; }
        public DepartmentToListDTO Department { get; set; }
    }
}
