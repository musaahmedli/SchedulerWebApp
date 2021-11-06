using AutoMapper;
using BusinessLogicLib.IServices;
using DataAccessLib.IRepositories;
using DTO.OrganizationDTOs;
using EntityLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLib.Services
{
    public class OrganizationService : IOrganizationService
    {
        private readonly IOrganizationRepo _repo;
        private readonly IMapper _mapper;
        public OrganizationService(IOrganizationRepo repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }
        public async Task Add(OrganizationToAddDTO organizationToAddDTO)
        {
            await _repo.Add(_mapper.Map<Organization>(organizationToAddDTO));
        }

        public async Task Delete(int organizationId)
        {
            await _repo.Delete(organizationId);
        }

        public async Task<List<OrganizationToListDTO>> Get()
        {
            return _mapper.Map<List<OrganizationToListDTO>>(await _repo.Get());
        }

        public async Task<OrganizationToListDTO> GetById(int organizationId)
        {
            return _mapper.Map<OrganizationToListDTO>(await _repo.GetById(organizationId));
        }

        public void Update(OrganizationToUpdateDTO organizationToUpdateDTO)
        {
            _repo.Update(_mapper.Map<Organization>(organizationToUpdateDTO));
        }
    }
}
