using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.OrganizationDTOs
{
    public class OrganizationToListDTO
    {
        public int OrganizationId { get; set; }
        public string Name { get; set; }
        public int? ParentOrganizationId { get; set; }
        public OrganizationToListDTO ParentOrganization { get; set; }
    }
}
