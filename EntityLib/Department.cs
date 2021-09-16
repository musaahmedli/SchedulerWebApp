using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLib
{
    public class Department
    {
        [Key]
        public int DepartmentId { get; set; }
        [Required]
        public string Name { get; set; }
        public bool IsDeleted { get; set; }
        [ForeignKey("Organization")]
        public int OrganizationId { get; set; }
        public virtual Organization Organization { get; set; }
    }
}
