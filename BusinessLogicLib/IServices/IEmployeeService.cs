using DTO.EmployeeDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLib.IServices
{
    public interface IEmployeeService
    {
        Task Add(EmployeeToAddDTO employee);
        Task<List<EmployeeToListDTO>> Get();
        Task<EmployeeToListDTO> GetById(int employeeId);
        Task Delete(int employeeId);
        void Update(EmployeeToUpdateDTO employee);
        Task<List<EmployeeToListDTO>> GetDeleteds();
        Task<bool> Login(EmployeeToListDTO employee);
    }
}
