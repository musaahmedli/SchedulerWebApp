using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLib
{
    public class DaysOfWeek
    {
        [Key]
        public int DayId { get; set; }
        public string Day { get; set; }
    }
}
