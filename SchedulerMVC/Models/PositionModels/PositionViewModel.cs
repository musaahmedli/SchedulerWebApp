using DTO.PositionDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchedulerMVC.Models.PositionModels
{
    public class PositionViewModel
    {
        public List<PositionToListDTO> Positions { get; set; }
        public string Authorization { get; set; }
    }
}
