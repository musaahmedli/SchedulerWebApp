using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.OrganizationDTOs
{
    public class OrganizationToUpdateDTO
    {
        public int OrganizationId { get; set; }
        public string Name { get; set; }
        public int? ParentOrganizationId { get; set; }
    }
}
