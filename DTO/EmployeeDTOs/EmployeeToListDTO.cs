using DTO.PositionDTOs;
using DTO.SectorDTOs;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.EmployeeDTOs
{
    public class EmployeeToListDTO
    {
        public int EmployeeId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Username { get; set; }
        public string EMail { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public bool IsAdmin { get; set; }
        public string ImagePath { get; set; }
        public int SectorId { get; set; }
        public SectorToListDTO Sector { get; set; }
        public int PositionId { get; set; }
        public PositionToListDTO Position { get; set; }
    }
}
