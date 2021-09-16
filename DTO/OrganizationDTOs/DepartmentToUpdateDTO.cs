using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.OrganizationDTOs
{
    public class DepartmentToUpdateDTO
    {
        public int DepartmentId { get; set; }
        public string Name { get; set; }
        public int OrganizationId { get; set; }
    }
}
