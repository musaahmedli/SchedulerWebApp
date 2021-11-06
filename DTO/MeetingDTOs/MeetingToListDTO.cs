﻿using DTO.EmployeeDTOs;
using DTO.EmployeeMeetingDTOs;
using DTO.MeetingDays;
using DTO.ProjectDTOs;
using EntityLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.MeetingDTOs
{
    public class MeetingToListDTO
    {
        public int MeetingId { get; set; }
        public string Subject { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public int ProjectId { get; set; }
        public ProjectToListDTO Project { get; set; }
        public int EmployeeId { get; set; }
        public List<EmployeeMeetingToListDTO> EmployeeMeetings { get; set; }
        public int MeetingDaysId { get; set; }
        public MeetingDaysToListDTO MeetingDay { get; set; }
    }
}
