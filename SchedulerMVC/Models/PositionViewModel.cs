using DTO.PositionDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchedulerMVC.Models
{
    public class PositionViewModel
    {
        public List<PositionToListDTO> Positions { get; set; }
    }
}
