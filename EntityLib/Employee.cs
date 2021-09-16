using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace EntityLib
{
    public class Employee
    {
        [Key]
        public int EmployeeId { get; set; }
        [Required]
        public string Username { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [MinLength(6, ErrorMessage = "Sifre 6 simvoldan cox olmalidir")]
        public string Password { get; set; }
        [Required]
        [DataType(DataType.EmailAddress, ErrorMessage = "E-Mail duzgun daxil edilmeyib")]
        public string Email { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
        public string ImagePath { get; set; }
        [NotMapped]
        public IFormFile Image { get; set; }
        public bool IsAdmin { get; set; }
        public bool IsDeleted { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Surname { get; set; }
        [ForeignKey("Sector")]
        public int SectorId { get; set; }
        public virtual Sector Sector { get; set; }
        [ForeignKey("Position")]
        public int PositionId { get; set; }
        public virtual Position Position { get; set; }
        public virtual List<EmployeeMeeting> EmployeeMeetings { get; set; }
    }
}
