using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityLib
{
    public class Organization
    {
        public int OrganizationId { get; set; }
        [Required]
        public string Name { get; set; }
        public bool IsDeleted { get; set; }
        [ForeignKey("ParentOrganization")]
        public int? ParentOrganizationId { get; set; }
        public virtual Organization ParentOrganization { get; set; }
    }
}
