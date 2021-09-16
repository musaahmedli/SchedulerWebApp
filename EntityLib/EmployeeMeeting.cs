using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLib
{
    public class EmployeeMeeting
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("Employee")]
        public int EmployeeId { get; set; }
        public virtual Employee Employee { get; set; }
        [ForeignKey("Meeting")]
        public int MeetingId { get; set; }
        public virtual Meeting Meeting { get; set; }

    }
}
