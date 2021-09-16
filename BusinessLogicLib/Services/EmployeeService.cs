using AutoMapper;
using BusinessLogicLib.IServices;
using DataAccessLib.IRepositories;
using DTO.EmployeeDTOs;
using EntityLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLib.Services
{
    public class EmployeeService:IEmployeeService
    {
        private readonly IEmployeeRepo _repo;
        private readonly IMapper _mapper;
        public EmployeeService(IMapper mapper,IEmployeeRepo repo)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task Add(EmployeeToAddDTO employee)
        {
            await _repo.Add(_mapper.Map<Employee>(employee));
        }

        public async Task<List<EmployeeToListDTO>> Get()
        {
            List<Employee> employees =await _repo.Get();
            return _mapper.Map<List<EmployeeToListDTO>>(employees);
        }

        public async Task<EmployeeToListDTO> GetById(int employeeId)
        {
            return _mapper.Map<EmployeeToListDTO>(await _repo.GetById(employeeId));
        }

        public async Task Delete(int employeeId)
        {
            await _repo.Delete(employeeId);
        }

        public void Update(EmployeeToUpdateDTO employee)
        {
            _repo.Update(_mapper.Map<Employee>(employee));
        }

        public async Task<List<EmployeeToListDTO>> GetDeleteds()
        {
            return _mapper.Map<List<EmployeeToListDTO>>(await _repo.GetDeleteds());
        }

        public async Task<bool> Login(EmployeeToListDTO employee)
        {

            if (await _repo.Login(_mapper.Map<Employee>(employee)))
            {
                return true;
            }
            return false;
        }
    }
}
