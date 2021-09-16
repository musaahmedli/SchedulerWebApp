using DTO.ProjectDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLib.IServices
{
    public interface IProjectService
    {
        Task Add(ProjectToAddDTO project);
        Task Delete(int projectId);
        Task<List<ProjectToListDTO>> Get();
        Task<ProjectToListDTO> GetById(int projectId);
        void Update(ProjectToUpdateDTO project);
        Task<List<ProjectToListDTO>> GetDeleteds();
    }
}
