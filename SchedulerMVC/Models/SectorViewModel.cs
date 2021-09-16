using DTO.SectorDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchedulerMVC.Models
{
    public class SectorViewModel
    {
        public List<SectorToListDTO> sectors { get; set; }
    }
}
