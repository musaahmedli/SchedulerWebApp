using DTO.MeetingDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchedulerMVC.Models.MeetingModels
{
    public class MeetingViewModel
    {
        public List<MeetingToListDTO> Meetings { get; set; }
        public string Authorization { get; set; }
    }
}
