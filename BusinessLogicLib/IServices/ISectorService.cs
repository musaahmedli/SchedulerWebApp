using DTO.SectorDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLib.IServices
{
    public interface ISectorService
    {
        Task Add(SectorToAddDTO sector);
        Task<List<SectorToListDTO>> Get();
        Task<SectorToListDTO> GetById(int sectorId);
        Task Delete(int sectorId);
        void Update(SectorToUpdateDTO sector);
        Task<List<SectorToListDTO>> GetSectorByDepartment(int departmentId);
    }
}
