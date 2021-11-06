using DTO.SectorDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchedulerMVC.Models.SectorModels
{
    public class SectorViewModel
    {
        public List<SectorToListDTO> sectors { get; set; }
        public string Authorization { get; set; }
    }
}
