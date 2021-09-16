using DTO.OrganizationDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLib.IServices
{
    public interface IDepartmentService
    {
        Task Add(DepartmentToAddDTO department);
        Task<List<DepartmentToListDTO>> Get();
        Task<DepartmentToListDTO> GetById(int departmentId);
        Task Delete(int departmentId);
        void Update(DepartmentToUpdateDTO department);
        Task<List<DepartmentToListDTO>> GetDeleteds();
    }
}
