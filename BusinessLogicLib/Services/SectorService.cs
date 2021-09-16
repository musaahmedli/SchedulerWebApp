using AutoMapper;
using BusinessLogicLib.IServices;
using DataAccessLib.IRepositories;
using DTO.SectorDTOs;
using EntityLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLib.Services
{
    public class SectorService : ISectorService
    {
        private readonly ISectorRepo _repo;
        private readonly IMapper _mapper;
        public SectorService(ISectorRepo repo,IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }
        public async Task Add(SectorToAddDTO sector)
        {
            await _repo.Add(_mapper.Map<Sector>(sector));
        }

        public async Task Delete(int sectorId)
        {
            await _repo.Delete(sectorId);
        }

        public async Task<List<SectorToListDTO>> Get()
        {
            return _mapper.Map<List<SectorToListDTO>>(await _repo.Get());
        }

        public async Task<SectorToListDTO> GetById(int sectorId)
        {
            return _mapper.Map<SectorToListDTO>(await _repo.GetById(sectorId));
        }

        public async Task<List<SectorToListDTO>> GetDeleteds()
        {
            return _mapper.Map<List<SectorToListDTO>>(await _repo.ShowDeletedOrganizations());
        }

        public void Update(SectorToUpdateDTO sector)
        {
            _repo.Update(_mapper.Map<Sector>(sector));
        }
    }
}
