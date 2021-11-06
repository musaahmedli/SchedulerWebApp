using DTO.PositionDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLib.IServices
{
    public interface IPositionService
    {
        Task Add(PositionToAddDTO positionToAddDTO);
        Task<List<PositionToListDTO>> Get();
        Task<PositionToListDTO> GetById(int positionId);
        Task Delete(int positionId);
        void Update(PositionToUpdateDTO positionToUpdateDTO);
    }
}
