using AutoMapper;
using BusinessLogicLib.IServices;
using DataAccessLib.IRepositories;
using DTO.PositionDTOs;
using EntityLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLib.Services
{
    public class PositionService : IPositionService
    {
        private readonly IPositionRepo _repo;
        private readonly IMapper _mapper;
        public PositionService(IPositionRepo repo,IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }
        public async Task Add(PositionToAddDTO positionToAddDTO)
        {
            await _repo.Add(_mapper.Map<Position>(positionToAddDTO));
        }

        public async Task Delete(int positionId)
        {
            await _repo.Delete(positionId);
        }

        public async Task<List<PositionToListDTO>> Get()
        {
            return _mapper.Map<List<PositionToListDTO>>(await _repo.Get());
        }

        public async Task<PositionToListDTO> GetById(int positionId)
        {
            return _mapper.Map<PositionToListDTO>(await _repo.GetById(positionId));
        }

        public async Task<List<PositionToListDTO>> GetDeleteds()
        {
            return _mapper.Map<List<PositionToListDTO>>(await _repo.GetDeleteds());
        }

        public void Update(PositionToUpdateDTO positionToUpdateDTO)
        {
            _repo.Update(_mapper.Map<Position>(positionToUpdateDTO));
        }
    }
}
