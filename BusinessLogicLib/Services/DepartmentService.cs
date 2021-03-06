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
    public class DepartmentService : IDepartmentService
    {
        private readonly IDepartmentRepo _repo;
        private readonly IMapper _mapper;
        public DepartmentService(IDepartmentRepo repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }
        public async Task Add(DepartmentToAddDTO department)
        {
            await _repo.Add(_mapper.Map<Department>(department));
        }

        public async Task Delete(int departmentId)
        {
            await _repo.Delete(departmentId);
        }

        public async Task<List<DepartmentToListDTO>> Get()
        {
            List<DepartmentToListDTO> list = _mapper.Map<List<DepartmentToListDTO>>(await _repo.Get());
            return list;
        }

        public async Task<DepartmentToListDTO> GetById(int departmentId)
        {
            return _mapper.Map<DepartmentToListDTO>(await _repo.GetById(departmentId));
        }

        public async Task<List<DepartmentToListDTO>> GetDepartmentsByOrganization(int organizationId)
        {
            List<DepartmentToListDTO> departments = _mapper.Map<List<DepartmentToListDTO>>(await _repo.GetDepartmentsByOrganizationId(organizationId));
            return departments;
        }

        public void Update(DepartmentToUpdateDTO department)
        {
            _repo.Update(_mapper.Map<Department>(department));
        }
    }
}
