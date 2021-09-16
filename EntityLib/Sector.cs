using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLib
{
    public class Sector
    {
        [Key]
        public int SectorId { get; set; }
        [Required]
        public string Name { get; set; }
        public bool IsDeleted { get; set; }
        [ForeignKey("Department")]
        public int DepartmentId { get; set; }
        public virtual Department Department { get; set; }
    }
}
